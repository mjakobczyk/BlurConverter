namespace MAIN_PROGRAM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Output_Picture_Box = new System.Windows.Forms.PictureBox();
            this.Loading_Path_Tbx = new System.Windows.Forms.TextBox();
            this.Loading_Path_Btn = new System.Windows.Forms.Button();
            this.Saving_Path_Btn = new System.Windows.Forms.Button();
            this.Input_Picture_Box = new System.Windows.Forms.PictureBox();
            this.Saving_Path_Tbx = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.DLL_Choice_TBX = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Output_Picture_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_Picture_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // Output_Picture_Box
            // 
            this.Output_Picture_Box.Location = new System.Drawing.Point(492, 284);
            this.Output_Picture_Box.Name = "Output_Picture_Box";
            this.Output_Picture_Box.Size = new System.Drawing.Size(426, 222);
            this.Output_Picture_Box.TabIndex = 6;
            this.Output_Picture_Box.TabStop = false;
            // 
            // Loading_Path_Tbx
            // 
            this.Loading_Path_Tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Loading_Path_Tbx.Location = new System.Drawing.Point(195, 83);
            this.Loading_Path_Tbx.Name = "Loading_Path_Tbx";
            this.Loading_Path_Tbx.ReadOnly = true;
            this.Loading_Path_Tbx.Size = new System.Drawing.Size(723, 24);
            this.Loading_Path_Tbx.TabIndex = 7;
            // 
            // Loading_Path_Btn
            // 
            this.Loading_Path_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Loading_Path_Btn.Location = new System.Drawing.Point(41, 81);
            this.Loading_Path_Btn.Name = "Loading_Path_Btn";
            this.Loading_Path_Btn.Size = new System.Drawing.Size(130, 26);
            this.Loading_Path_Btn.TabIndex = 8;
            this.Loading_Path_Btn.Text = "Loading Path";
            this.Loading_Path_Btn.UseVisualStyleBackColor = true;
            this.Loading_Path_Btn.Click += new System.EventHandler(this.Loading_Path_Btn_Click);
            // 
            // Saving_Path_Btn
            // 
            this.Saving_Path_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Saving_Path_Btn.Location = new System.Drawing.Point(41, 130);
            this.Saving_Path_Btn.Name = "Saving_Path_Btn";
            this.Saving_Path_Btn.Size = new System.Drawing.Size(130, 26);
            this.Saving_Path_Btn.TabIndex = 9;
            this.Saving_Path_Btn.Text = "Saving Path";
            this.Saving_Path_Btn.UseVisualStyleBackColor = true;
            this.Saving_Path_Btn.Click += new System.EventHandler(this.Saving_Path_Btn_Click);
            // 
            // Input_Picture_Box
            // 
            this.Input_Picture_Box.Location = new System.Drawing.Point(41, 284);
            this.Input_Picture_Box.Name = "Input_Picture_Box";
            this.Input_Picture_Box.Size = new System.Drawing.Size(426, 222);
            this.Input_Picture_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Input_Picture_Box.TabIndex = 10;
            this.Input_Picture_Box.TabStop = false;
            // 
            // Saving_Path_Tbx
            // 
            this.Saving_Path_Tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Saving_Path_Tbx.Location = new System.Drawing.Point(195, 132);
            this.Saving_Path_Tbx.Name = "Saving_Path_Tbx";
            this.Saving_Path_Tbx.Size = new System.Drawing.Size(723, 24);
            this.Saving_Path_Tbx.TabIndex = 11;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(195, 178);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(38, 21);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "C";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // DLL_Choice_TBX
            // 
            this.DLL_Choice_TBX.BackColor = System.Drawing.SystemColors.MenuBar;
            this.DLL_Choice_TBX.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DLL_Choice_TBX.Location = new System.Drawing.Point(41, 178);
            this.DLL_Choice_TBX.Multiline = true;
            this.DLL_Choice_TBX.Name = "DLL_Choice_TBX";
            this.DLL_Choice_TBX.Size = new System.Drawing.Size(130, 26);
            this.DLL_Choice_TBX.TabIndex = 13;
            this.DLL_Choice_TBX.Text = "DLL";
            this.DLL_Choice_TBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.DLL_Choice_TBX);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.Saving_Path_Tbx);
            this.Controls.Add(this.Input_Picture_Box);
            this.Controls.Add(this.Saving_Path_Btn);
            this.Controls.Add(this.Loading_Path_Btn);
            this.Controls.Add(this.Loading_Path_Tbx);
            this.Controls.Add(this.Output_Picture_Box);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Output_Picture_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_Picture_Box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Output_Picture_Box;
        private System.Windows.Forms.TextBox Loading_Path_Tbx;
        private System.Windows.Forms.Button Loading_Path_Btn;
        private System.Windows.Forms.Button Saving_Path_Btn;
        private System.Windows.Forms.PictureBox Input_Picture_Box;
        private System.Windows.Forms.TextBox Saving_Path_Tbx;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox DLL_Choice_TBX;
    }
}

