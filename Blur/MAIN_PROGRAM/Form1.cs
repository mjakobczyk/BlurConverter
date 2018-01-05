/*
 * Klasa g��wna programu zawieraj�ca GUI programu.
 * Implementuje w�a�ciwy wygl�d aplikacji.
 * Obs�uguje ��dania u�ytkownika za pomoc� dost�pnych metod interfejsu u�ytkownika.
 * 
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAIN_PROGRAM
{
    public partial class Form1 : Form
    {
        #region Imports

        // Funcion import from C
        [DllImport("DLL_C.dll")]
        public static extern void BlurTransformRowC(int width, int height, int radius, byte[] row, byte[] surrounding);

        // Function import from ASM
        [DllImport("DLL_ASM.dll")]
        public static extern void BlurTransformRowASM(int width, int height, byte[] row, byte[] surroundingArea, int radius);

        #endregion

        #region Variables

        public enum Conversion { UNKNOWN = 0, C = 1, ASM = 2 };
        private  Conversion conversionType = 0;

        private static Image inputPicture = null;
        private static String inputPicturePath;
        private static String outputPicturePath;

        private static Bitmap inputBitmap = null;
        private static Bitmap outputBitmap = null;

        private byte [][] inputArray;
        private byte [][] outputArray;

        private int arrayHeight = 0;
        private int arrayWidth = 0;

        private bool inputPathSet = false;
        private bool outputPathSet = false;
        private bool conversionMethodSet = false;

        private int threadsAmount = 0;
        private int radius = 0;

        #endregion

        #region Functions

        // Funkcja konwertuj�ca bitmap� na tablic� dwuwymiarow�
        // @param bitmap - bitmapa przekaza do programu przez u�ytkownika
        private void BitmapToArray(Bitmap bitmap)
        {
            // Zczytaj wysoko�� bitmapy
            arrayHeight = bitmap.Height;

            // Zczytaj szeroko�� bitmapy i przemn� j� przez 3
            // ze wzgl�du na system Red Green Blue
            arrayWidth = bitmap.Width * 3; 

            // Zainicjalizuj tablic� reprezentuj�c� bitmap�
            inputArray = new byte[arrayHeight][];

            // Przejd� po ka�dym wierszu bitmapy
            for (int y = 0; y < arrayHeight; y++)
            {
                // Zaalokuj pami�� dla ka�dego wiersza w zale�no�ci
                // od szeroko�ci wej�ciowej bitmapy
                inputArray[y] = new byte[arrayWidth];

                // Dla ka�dego wiersza bitmapy zczytaj po kolei ka�dy 
                // piksel i jego poszczeg�le warto�ci RGB. Iteracja
                // nast�puj�ce w ilo�ci arrayWidth / 3, poniewa�
                // dok�adnie tyle znajduje si� pikseli w wierszu.
                // W �rodku iteracji odwo�ujemy si� do kolejnych
                // warto�ci RGB piksela poprzez offset +0, +1, +2.
                for (int x = 0; x < arrayWidth / 3; x++)
                {
                    // Klasa Color pozwala pobra� pojedynczy piksel
                    // z bitmapy i wyodr�bni� z niego ka�d� warto��
                    Color pixel = bitmap.GetPixel(x, y);

                    inputArray[y][3 * x]     = pixel.R;
                    inputArray[y][3 * x + 1] = pixel.G;
                    inputArray[y][3 * x + 2] = pixel.B;
                }
            }
        }

        // Funkcja konwertuj�ca tablic� na bitmap�
        private void ArrayToBitmap(byte[][] array)
        {
            // Alokujemy pami�� dla wynikowej bitmapy
            outputBitmap = new Bitmap(arrayWidth / 3, arrayHeight);

            for (int y = 0; y < arrayHeight; y++)
            {
                for (int x = 0; x < arrayWidth / 3; x++)
                {
                    int r = outputArray[y][x * 3];
                    int g = outputArray[y][x * 3 + 1];
                    int b = outputArray[y][x * 3 + 2];

                    Color color = Color.FromArgb(r, g, b);
                    outputBitmap.SetPixel(x, y, color);
                }
            }
        }

        // Funkcja kopiuj�ca oryginaln� tablic� do wyj�ciowej tablicy
        private void CopyOriginalToOutputArray()
        {
            outputArray = new byte[arrayHeight][];
            for (int y = 0; y < arrayHeight; y++)
            {
                outputArray[y] = new byte[arrayWidth];
                for (int x = 0; x < arrayWidth; x++)
                {
                    outputArray[y][x] = inputArray[y][x];
                }
            }
        }

        // Funkcja wykonuj�ca w�a�ciw� konwersj� obrazu na blur
        private void ToBlur()
        {
            // Definicja opcji do ustawie� wsp�bie�no�ci
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = threadsAmount
            };

            // Wykonaj konwersj�
            Parallel.ForEach(outputArray, options, (row, state, index) =>
            {
                // Wysoko�� lokalnej tablicy obliczanej na podstawie
                // wybranego przez u�ytkownika promienia
                int localArrayHeight = 1 + 2 * radius;

                // Lokalna tablica
                byte[] surroundingArea;

                // Utw�rz lokaln� tablic� odzwierciedlaj�c� bezpo�redni
                // obszar wok� zadanego wiersza obliczanego przez dany
                // w�tek. Obszar ten jest zale�ny od wybranego przez
                // u�ytkownika promienia 
                surroundingArea = new byte[localArrayHeight * arrayWidth];

                // Je�eli indeks wiersza znajduje si� w przedziale od
                // g�rnego marginesu do promienia
                if (index >= 0 && index < radius)
                {
                    for (int j = 0; j < localArrayHeight; ++j)
                    {
                        int temporaryRowAccess = 0;
                        int offset = Convert.ToInt32(index) - radius + j;

                        if (offset < 0)
                        {
                            temporaryRowAccess = arrayHeight - 1 + offset;
                        }

                        for (int i = 0; i < arrayWidth; i += 3)
                        {
                            if (temporaryRowAccess > 0)
                            {
                                surroundingArea[(j * (arrayWidth)) + i] = inputArray[temporaryRowAccess][i];
                                surroundingArea[(j * (arrayWidth)) + i + 1] = inputArray[temporaryRowAccess][i + 1];
                                surroundingArea[(j * (arrayWidth)) + i + 2] = inputArray[temporaryRowAccess][i + 2];
                            }
                            else
                            {
                                surroundingArea[(j * (arrayWidth)) + i] = inputArray[index - radius + j][i];
                                surroundingArea[(j * (arrayWidth)) + i + 1] = inputArray[index - radius + j][i + 1];
                                surroundingArea[(j * (arrayWidth)) + i + 2] = inputArray[index - radius + j][i + 2];
                            }
                        }

                    }
                }
                // Je�eli indeks wiersza znajduje si� w miejscu, gdzie
                // zawsze b�dzie obszar do pobrania (nie wykracza poza
                // marginesy z �adnej strony)
                else if (index >= radius && index < (arrayHeight - radius))
                {
                    // Przeiteruj przez ca�� tablic� wej�ciow� dla danego
                    // obszaru i przekopiuj z niej elementy do lokalnej
                    // tablicy, kt�ra bedzie przekazana do DLL
                    for (int j = 0; j < localArrayHeight; ++j)
                    {
                        for (int i = 0; i < arrayWidth; i += 3)
                        {
                            // Przekopiuj wszystkie warto�ci RBG
                            surroundingArea[(j * (arrayWidth)) + i] = inputArray[index - radius + j][i];
                            surroundingArea[(j * (arrayWidth)) + i + 1] = inputArray[index - radius + j][i + 1];
                            surroundingArea[(j * (arrayWidth)) + i + 2] = inputArray[index - radius + j][i + 2];
                        }
                    }

                }
                // Je�eli indeks wiersza znajduje si� w przedziale od
                // dolnego promienia do dolnego marginesu bitmapy
                else if (index >= (arrayHeight - radius) && index < (arrayHeight - 1))
                {
                    for (int j = 0; j < localArrayHeight; ++j)
                    {
                        int temporaryRowAccess = (arrayHeight - 1);
                        int offset = Convert.ToInt32(index) - radius + j;

                        if (offset > (arrayHeight - 1))
                        {
                            temporaryRowAccess = offset - (arrayHeight);
                        }

                        for (int i = 0; i < arrayWidth; i += 3)
                        {
                            if (temporaryRowAccess < (arrayHeight - 1))
                            {
                                surroundingArea[(j * (arrayWidth)) + i] = inputArray[temporaryRowAccess][i];
                                surroundingArea[(j * (arrayWidth)) + i + 1] = inputArray[temporaryRowAccess][i + 1];
                                surroundingArea[(j * (arrayWidth)) + i + 2] = inputArray[temporaryRowAccess][i + 2];
                            }
                            else
                            {
                                surroundingArea[(j * (arrayWidth)) + i] = inputArray[index - radius + j][i];
                                surroundingArea[(j * (arrayWidth)) + i + 1] = inputArray[index - radius + j][i + 1];
                                surroundingArea[(j * (arrayWidth)) + i + 2] = inputArray[index - radius + j][i + 2];
                            }
                        }

                    }
                }

                // Dla DLL napisanej w C
                if (conversionType.Equals(Conversion.C))
                {
                    // Wywo�aj w�a�ciw� funkcj�
                    BlurTransformRowC(arrayWidth, localArrayHeight, radius, row, surroundingArea);
                }
                // Dla DLL napisanej w ASM
                else if (conversionType.Equals(Conversion.ASM))
                {
                    // Wykonaj konwersj�
                    BlurTransformRowASM(arrayWidth, localArrayHeight, row, surroundingArea, radius);
                }
            });

            return;
        }

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();
            C_RadioBtn.Checked = true;
            ASM_RadioBtn.Checked = false;
            this.conversionMethodSet = true;
            Threads_Chkbx.Checked = true;
            Radius_Tbx.Text = "1";
            Radius_Trb.Value = 1;
        }

        #endregion

        #region Buttons

        private void Loading_Path_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            inputFileDialog.Filter = "JPG(*.JPG)|*.jpg|PNG(*.PNG)|*.png";
            if (inputFileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                inputPicture = Image.FromFile(inputFileDialog.FileName);
                inputPicturePath = inputFileDialog.FileName;

                inputBitmap = new Bitmap(inputPicture);
                Input_Picture_Box.Image = inputPicture;
                Loading_Path_Tbx.Text = inputPicturePath;

                String extension = inputPicturePath.Substring(inputPicturePath.Length - 4);
                String outputPath = inputPicturePath.Length <= 4 ? inputPicturePath : inputPicturePath.Remove(inputPicturePath.Length - 4);
                outputPath = outputPath + "Blur" + extension;
                Saving_Path_Tbx.Text = outputPath;
                outputPicturePath = outputPath;

                this.BitmapToArray(inputBitmap);
                this.inputPathSet = true;
                this.outputPathSet = true;
            }
            else
            {
                if (Loading_Path_Tbx.Text == "" || Loading_Path_Tbx.Text == null)
                    this.inputPathSet = false;
            }

            return;
        }

        private void Saving_Path_Btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog outputFileDialog = new SaveFileDialog();
            outputFileDialog.Filter = "JPG(*.JPG)|*.jpg|PNG(*.PNG)|*.png";
            if (outputFileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                Saving_Path_Tbx.Text = outputFileDialog.FileName;
                outputPicturePath = outputFileDialog.FileName;

                this.outputPathSet = true;
            }
            else
            {
                if (Saving_Path_Tbx.Text == "" || Saving_Path_Tbx.Text == null)
                    this.outputPathSet = false;
            }

            return;
        }

        // Przycisk konwersji uruchamiaj�cy dzia�anie w�a�ciwe programu
        private void Convert_Btn_Click(object sender, EventArgs e)
        {
            // Sprawdzenie najwa�niejszych flag z miejsc, gdzie u�ytkownik
            // jest zobligowany do wprowadzenia manualnie informacji
            if (inputPathSet == false || outputPathSet == false || conversionMethodSet == false)
            {
                MessageBox.Show("Fill all fields before running the application!", "Conversion error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pobierz warto�ci z textbox�w odpowiadaj�cych parametrom
            // wywo�ywanego programy
            Int32.TryParse(Radius_Tbx.Text, out int RadiusValueFromTheTbx);
            Int32.TryParse(Threads_Tbx.Text, out int ThreadsValueFromTheTbx);

            // Przypisz pobrane warto�ci od odpowiednich zmiennych
            // przekazywanych p�niej do bibliotek
            this.threadsAmount = ThreadsValueFromTheTbx;
            this.radius = RadiusValueFromTheTbx;

            // Skopiuj tablic� wej�ciow� do tablicy wyj�ciowej
            this.CopyOriginalToOutputArray();

            // Rozpoczij diagnostyk� mierzenia czasu
            var watch = System.Diagnostics.Stopwatch.StartNew();
            this.ToBlur();
            watch.Stop();
            // Po wykonaniu algorytmu zatrzymaj stoper
            
            // Przypisz zmierzony czas do zmiennej w celu jej
            // p�niejszego odczytania
            var elapsedMs = watch.ElapsedMilliseconds;

            // W zale�no�ci od tego kt�ra biblioteka zosta�a
            // wybrana przypisz zmierzony czas w odpowiednie]
            // miejsce
            if (conversionType.Equals(Conversion.C))
            {
                C_ExeTime_Tbx.Text = elapsedMs.ToString();
            }
            else if (conversionType.Equals(Conversion.ASM))
            {
                ASM_ExeTime_Tbx.Text = elapsedMs.ToString();
            }

            // W celu pokazania efektu ko�cowego skonwertuj
            // wynikow� tablic� wyj�ciow� do bitmapy
            this.ArrayToBitmap(outputArray);

            // Ustaw bitmap� w okienku w programie
            Output_Picture_Box.Image = outputBitmap;

            // Zapisz bitmap� do wskazanego pliku
            outputBitmap.Save(outputPicturePath);
        }

        #endregion

        #region TextBoxes

        private void Threads_Tbx_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode.Equals(Keys.Enter))
            //{
            //    bool actionSuccesful = Int32.TryParse(Threads_Tbx.Text, out int valueFromTheTbx);

            //    if (actionSuccesful && (valueFromTheTbx == (int)valueFromTheTbx))
            //    {
            //        if (valueFromTheTbx < 1 || valueFromTheTbx > 64)
            //        {
            //            MessageBox.Show(valueFromTheTbx + " is not correct value! Type between 1 - 64", "Threads error",
            //                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            Threads_Tbx.Text = "0";
            //            this.threadsSet = false;
            //        }
            //        else
            //        {
            //            this.threadsSet = true;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(valueFromTheTbx + " is not correct value! Type between 1 - 64!", "Threads error",
            //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        Threads_Tbx.Text = "0";
            //        this.threadsSet = false;
            //    }

            //    e.Handled = true;
            //    e.SuppressKeyPress = true;
            //}
        }

        #endregion

        #region RadioButtons

        private void C_RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            this.conversionType = (Conversion)1;
        }

        private void ASM_RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            this.conversionType = (Conversion)2;
        }

        #endregion

        #region CheckBoxes

        private void Threads_Chkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (Threads_Chkbx.Checked)
            {
                Threads_Tbx.Text = "64";
                Threads_Trb.Value = 64;
                Threads_Trb.Enabled = false;
            }
            else
            {
                Threads_Tbx.Text = "1";
                Threads_Trb.Value = 1;
                Threads_Trb.Enabled = true;
            }
        }

        #endregion

        #region TrackBars

        private void Radius_Trb_Scroll(object sender, EventArgs e)
        {
            Radius_Tbx.Text = Radius_Trb.Value.ToString();
        }

        private void Threads_Trb_Scroll(object sender, EventArgs e)
        {
            Threads_Tbx.Text = Threads_Trb.Value.ToString();
        }

        #endregion

    }
}
