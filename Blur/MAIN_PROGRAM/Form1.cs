using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAIN_PROGRAM
{
    public partial class Form1 : Form
    {
        #region Imports

        // Funcion import from C

        [DllImport("DLL_C.dll")]
        public static extern void blurTransformRowC(byte[] row, int rowSize, int radius);

        // Function import from ASM

        [DllImport("DLL_ASM.dll")]
        public static extern void MyProc1(byte[] x, int y, int r);

        #endregion

        #region Variables

        private static Image inputPicture = null;
        private static String inputPicturePath;

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();
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
                Input_Picture_Box.Image = inputPicture;
                Loading_Path_Tbx.Text = inputPicturePath;
                // Saving_Path_Tbx.Text
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
            }

            return;
        }

        #endregion

        #region TextBoxes

        #endregion
    }
}
