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
        public static extern void BlurTransformRowC(byte[] row, int rowSize, int radius);

        // Function import from ASM

        [DllImport("DLL_ASM.dll")]
        public static extern void MyProc1(byte[] x, int y, int r);

        #endregion

        #region Variables

        public enum Conversion { UNKNOWN = 0, C = 1, ASM = 2 };
        private  Conversion conversionType = 0;

        private static Image inputPicture = null;
        private static String inputPicturePath;
        private static String outputPicturePath;

        private static Bitmap inputBitmap = null;
        private static Bitmap outputBitmap = null;

        private byte[][] inputArray;
        private byte[][] outputArray;

        private int arrayHeight = 0;
        private int arrayWidth = 0;
        private const int radius = 1;

        private bool inputPathSet = false;
        private bool outputPathSet = false;
        private bool conversionMethodSet = false;
        private bool threadsSet = false;

        #endregion

        #region Functions

        // Function converting bitmap into array
        private void BitmapToArray(Bitmap bitmap)
        {
            // Assign height and width values depending on the size
            // of the input bitmap. The width is mulptipled by 3
            // because of the RBG system
            arrayHeight = bitmap.Height;
            arrayWidth = bitmap.Width * 3; 
            inputArray = new byte[arrayHeight][];

            // Iterate through width and height to assign adequate
            // values for RGB
            for (int y = 0; y < arrayHeight; y++)
            {
                inputArray[y] = new byte[arrayWidth];

                for (int x = 1; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    inputArray[y][x * 3] = pixel.R;
                    inputArray[y][3 * x + 1] = pixel.G;
                    inputArray[y][3 * x + 2] = pixel.B;
                }
            }
        }

        // Function converting array into bitmap
        private void ArrayToBitmap(byte[][] array)
        {
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

        // Function copying original array to the output array
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

        // Function performing an action of blur conversion
        private void ToBlur()
        {
            Int32.TryParse(Threads_Tbx.Text, out int valueFromTheTbx);

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = valueFromTheTbx
            };

            if (conversionType.Equals(Conversion.C))
            {
                Parallel.ForEach(outputArray, options, (row, state, index) =>
                {
                    //if (index >= radius && index < arrayHeight)
                    //{
                    //    byte[][] surroundingArea = new byte[1 + 2 * radius][];
                    //}

                    BlurTransformRowC(row, arrayWidth / 3, 0);
                }
                );
            }
            else if (conversionType.Equals(Conversion.ASM))
            {
                Parallel.ForEach(outputArray, options, (row) => BlurTransformRowC(row, arrayWidth / 3, 0));
            }

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
            this.threadsSet = true;
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
                this.outputPathSet = false;
            }

            return;
        }

        private void Convert_Btn_Click(object sender, EventArgs e)
        {
            if (inputPathSet == false || outputPathSet == false || conversionMethodSet == false || threadsSet == false)
            {
                MessageBox.Show("Fill all fields before running the application!", "Conversion error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.CopyOriginalToOutputArray();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            this.ToBlur();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            //time.Text = elapsedMs.ToString();
            this.ArrayToBitmap(outputArray);
            Output_Picture_Box.Image = outputBitmap;
            outputBitmap.Save(outputPicturePath);
        }

        #endregion

        #region TextBoxes

        private void Threads_Tbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                bool actionSuccesful = Int32.TryParse(Threads_Tbx.Text, out int valueFromTheTbx);

                if (actionSuccesful && (valueFromTheTbx == (int)valueFromTheTbx))
                {
                    if (valueFromTheTbx < 1 || valueFromTheTbx > 64)
                    {
                        MessageBox.Show(valueFromTheTbx + " is not correct value! Type between 1 - 64", "Threads error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Threads_Tbx.Text = "0";
                        this.threadsSet = false;
                    }
                    else
                    {
                        this.threadsSet = true;
                    }
                }
                else
                {
                    MessageBox.Show(valueFromTheTbx + " is not correct value! Type between 1 - 64!", "Threads error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Threads_Tbx.Text = "0";
                    this.threadsSet = false;
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
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
                Threads_Tbx.Enabled = false;
                this.threadsSet = true;
            }
            else
            {
                Threads_Tbx.Enabled = true;
                Threads_Tbx.Text = "0";
                this.threadsSet = false;
            }
        }

        #endregion

    }
}
