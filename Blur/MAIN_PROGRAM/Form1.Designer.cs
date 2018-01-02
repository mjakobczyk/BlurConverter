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
            this.C_RadioBtn = new System.Windows.Forms.RadioButton();
            this.ASM_RadioBtn = new System.Windows.Forms.RadioButton();
            this.Title_Label = new System.Windows.Forms.Label();
            this.DLL_Label = new System.Windows.Forms.Label();
            this.Convert_Btn = new System.Windows.Forms.Button();
            this.Threads_Label = new System.Windows.Forms.Label();
            this.Threads_Tbx = new System.Windows.Forms.TextBox();
            this.Threads_Chkbx = new System.Windows.Forms.CheckBox();
            this.C_ExeTime_Label = new System.Windows.Forms.Label();
            this.ASM_ExeTime_Label = new System.Windows.Forms.Label();
            this.C_ExeTime_Tbx = new System.Windows.Forms.TextBox();
            this.ASM_ExeTime_Tbx = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Radius_Label = new System.Windows.Forms.Label();
            this.Radius_Trb = new System.Windows.Forms.TrackBar();
            this.Threads_Trb = new System.Windows.Forms.TrackBar();
            this.Radius_Tbx = new System.Windows.Forms.TextBox();
            this.Original_Image_Label = new System.Windows.Forms.Label();
            this.Converted_Image_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Output_Picture_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_Picture_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radius_Trb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Threads_Trb)).BeginInit();
            this.SuspendLayout();
            // 
            // Output_Picture_Box
            // 
            this.Output_Picture_Box.Location = new System.Drawing.Point(374, 269);
            this.Output_Picture_Box.Margin = new System.Windows.Forms.Padding(2);
            this.Output_Picture_Box.Name = "Output_Picture_Box";
            this.Output_Picture_Box.Size = new System.Drawing.Size(320, 180);
            this.Output_Picture_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Output_Picture_Box.TabIndex = 6;
            this.Output_Picture_Box.TabStop = false;
            // 
            // Loading_Path_Tbx
            // 
            this.Loading_Path_Tbx.Enabled = false;
            this.Loading_Path_Tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Loading_Path_Tbx.Location = new System.Drawing.Point(146, 67);
            this.Loading_Path_Tbx.Margin = new System.Windows.Forms.Padding(2);
            this.Loading_Path_Tbx.Name = "Loading_Path_Tbx";
            this.Loading_Path_Tbx.ReadOnly = true;
            this.Loading_Path_Tbx.Size = new System.Drawing.Size(543, 21);
            this.Loading_Path_Tbx.TabIndex = 7;
            // 
            // Loading_Path_Btn
            // 
            this.Loading_Path_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Loading_Path_Btn.Location = new System.Drawing.Point(31, 66);
            this.Loading_Path_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Loading_Path_Btn.Name = "Loading_Path_Btn";
            this.Loading_Path_Btn.Size = new System.Drawing.Size(98, 21);
            this.Loading_Path_Btn.TabIndex = 8;
            this.Loading_Path_Btn.Text = "Loading Path";
            this.Loading_Path_Btn.UseVisualStyleBackColor = true;
            this.Loading_Path_Btn.Click += new System.EventHandler(this.Loading_Path_Btn_Click);
            // 
            // Saving_Path_Btn
            // 
            this.Saving_Path_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Saving_Path_Btn.Location = new System.Drawing.Point(31, 106);
            this.Saving_Path_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Saving_Path_Btn.Name = "Saving_Path_Btn";
            this.Saving_Path_Btn.Size = new System.Drawing.Size(98, 21);
            this.Saving_Path_Btn.TabIndex = 9;
            this.Saving_Path_Btn.Text = "Saving Path";
            this.Saving_Path_Btn.UseVisualStyleBackColor = true;
            this.Saving_Path_Btn.Click += new System.EventHandler(this.Saving_Path_Btn_Click);
            // 
            // Input_Picture_Box
            // 
            this.Input_Picture_Box.Location = new System.Drawing.Point(31, 269);
            this.Input_Picture_Box.Margin = new System.Windows.Forms.Padding(2);
            this.Input_Picture_Box.Name = "Input_Picture_Box";
            this.Input_Picture_Box.Size = new System.Drawing.Size(320, 180);
            this.Input_Picture_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Input_Picture_Box.TabIndex = 10;
            this.Input_Picture_Box.TabStop = false;
            // 
            // Saving_Path_Tbx
            // 
            this.Saving_Path_Tbx.Enabled = false;
            this.Saving_Path_Tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Saving_Path_Tbx.Location = new System.Drawing.Point(146, 107);
            this.Saving_Path_Tbx.Margin = new System.Windows.Forms.Padding(2);
            this.Saving_Path_Tbx.Name = "Saving_Path_Tbx";
            this.Saving_Path_Tbx.ReadOnly = true;
            this.Saving_Path_Tbx.Size = new System.Drawing.Size(543, 21);
            this.Saving_Path_Tbx.TabIndex = 11;
            // 
            // C_RadioBtn
            // 
            this.C_RadioBtn.AutoSize = true;
            this.C_RadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.C_RadioBtn.Location = new System.Drawing.Point(146, 233);
            this.C_RadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.C_RadioBtn.Name = "C_RadioBtn";
            this.C_RadioBtn.Size = new System.Drawing.Size(33, 17);
            this.C_RadioBtn.TabIndex = 12;
            this.C_RadioBtn.TabStop = true;
            this.C_RadioBtn.Text = "C";
            this.C_RadioBtn.UseVisualStyleBackColor = true;
            this.C_RadioBtn.CheckedChanged += new System.EventHandler(this.C_RadioBtn_CheckedChanged);
            // 
            // ASM_RadioBtn
            // 
            this.ASM_RadioBtn.AutoSize = true;
            this.ASM_RadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ASM_RadioBtn.Location = new System.Drawing.Point(201, 233);
            this.ASM_RadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ASM_RadioBtn.Name = "ASM_RadioBtn";
            this.ASM_RadioBtn.Size = new System.Drawing.Size(51, 17);
            this.ASM_RadioBtn.TabIndex = 14;
            this.ASM_RadioBtn.TabStop = true;
            this.ASM_RadioBtn.Text = "ASM";
            this.ASM_RadioBtn.UseVisualStyleBackColor = true;
            this.ASM_RadioBtn.CheckedChanged += new System.EventHandler(this.ASM_RadioBtn_CheckedChanged);
            // 
            // Title_Label
            // 
            this.Title_Label.AutoSize = true;
            this.Title_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Title_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Title_Label.Location = new System.Drawing.Point(260, 9);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Size = new System.Drawing.Size(205, 33);
            this.Title_Label.TabIndex = 15;
            this.Title_Label.Text = "Blur Converter";
            this.Title_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DLL_Label
            // 
            this.DLL_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DLL_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DLL_Label.Location = new System.Drawing.Point(31, 229);
            this.DLL_Label.Name = "DLL_Label";
            this.DLL_Label.Size = new System.Drawing.Size(98, 21);
            this.DLL_Label.TabIndex = 16;
            this.DLL_Label.Text = "DLL";
            this.DLL_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Convert_Btn
            // 
            this.Convert_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Convert_Btn.Location = new System.Drawing.Point(303, 224);
            this.Convert_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Convert_Btn.Name = "Convert_Btn";
            this.Convert_Btn.Size = new System.Drawing.Size(120, 30);
            this.Convert_Btn.TabIndex = 17;
            this.Convert_Btn.Text = "CONVERT";
            this.Convert_Btn.UseVisualStyleBackColor = true;
            this.Convert_Btn.Click += new System.EventHandler(this.Convert_Btn_Click);
            // 
            // Threads_Label
            // 
            this.Threads_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Threads_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Threads_Label.Location = new System.Drawing.Point(31, 178);
            this.Threads_Label.Name = "Threads_Label";
            this.Threads_Label.Size = new System.Drawing.Size(98, 21);
            this.Threads_Label.TabIndex = 18;
            this.Threads_Label.Text = "Threads";
            this.Threads_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Threads_Tbx
            // 
            this.Threads_Tbx.Enabled = false;
            this.Threads_Tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Threads_Tbx.Location = new System.Drawing.Point(146, 177);
            this.Threads_Tbx.Margin = new System.Windows.Forms.Padding(2);
            this.Threads_Tbx.Name = "Threads_Tbx";
            this.Threads_Tbx.Size = new System.Drawing.Size(47, 21);
            this.Threads_Tbx.TabIndex = 19;
            this.Threads_Tbx.Text = "0";
            this.Threads_Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Threads_Tbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Threads_Tbx_KeyDown);
            // 
            // Threads_Chkbx
            // 
            this.Threads_Chkbx.AutoSize = true;
            this.Threads_Chkbx.Location = new System.Drawing.Point(146, 203);
            this.Threads_Chkbx.Name = "Threads_Chkbx";
            this.Threads_Chkbx.Size = new System.Drawing.Size(60, 17);
            this.Threads_Chkbx.TabIndex = 20;
            this.Threads_Chkbx.Text = "Default";
            this.Threads_Chkbx.UseVisualStyleBackColor = true;
            this.Threads_Chkbx.CheckedChanged += new System.EventHandler(this.Threads_Chkbx_CheckedChanged);
            // 
            // C_ExeTime_Label
            // 
            this.C_ExeTime_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.C_ExeTime_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.C_ExeTime_Label.Location = new System.Drawing.Point(147, 492);
            this.C_ExeTime_Label.Name = "C_ExeTime_Label";
            this.C_ExeTime_Label.Size = new System.Drawing.Size(204, 21);
            this.C_ExeTime_Label.TabIndex = 21;
            this.C_ExeTime_Label.Text = "C Execution Time: (ms)";
            this.C_ExeTime_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ASM_ExeTime_Label
            // 
            this.ASM_ExeTime_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ASM_ExeTime_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ASM_ExeTime_Label.Location = new System.Drawing.Point(146, 525);
            this.ASM_ExeTime_Label.Name = "ASM_ExeTime_Label";
            this.ASM_ExeTime_Label.Size = new System.Drawing.Size(204, 21);
            this.ASM_ExeTime_Label.TabIndex = 22;
            this.ASM_ExeTime_Label.Text = "ASM Execution Time: (ms)";
            this.ASM_ExeTime_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // C_ExeTime_Tbx
            // 
            this.C_ExeTime_Tbx.Enabled = false;
            this.C_ExeTime_Tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.C_ExeTime_Tbx.Location = new System.Drawing.Point(374, 492);
            this.C_ExeTime_Tbx.Margin = new System.Windows.Forms.Padding(2);
            this.C_ExeTime_Tbx.Name = "C_ExeTime_Tbx";
            this.C_ExeTime_Tbx.Size = new System.Drawing.Size(91, 21);
            this.C_ExeTime_Tbx.TabIndex = 23;
            this.C_ExeTime_Tbx.Text = "0";
            this.C_ExeTime_Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ASM_ExeTime_Tbx
            // 
            this.ASM_ExeTime_Tbx.Enabled = false;
            this.ASM_ExeTime_Tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.ASM_ExeTime_Tbx.Location = new System.Drawing.Point(374, 525);
            this.ASM_ExeTime_Tbx.Margin = new System.Windows.Forms.Padding(2);
            this.ASM_ExeTime_Tbx.Name = "ASM_ExeTime_Tbx";
            this.ASM_ExeTime_Tbx.Size = new System.Drawing.Size(91, 21);
            this.ASM_ExeTime_Tbx.TabIndex = 24;
            this.ASM_ExeTime_Tbx.Text = "0";
            this.ASM_ExeTime_Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(475, 557);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(259, 23);
            this.progressBar1.TabIndex = 25;
            // 
            // Radius_Label
            // 
            this.Radius_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Radius_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Radius_Label.Location = new System.Drawing.Point(31, 143);
            this.Radius_Label.Name = "Radius_Label";
            this.Radius_Label.Size = new System.Drawing.Size(98, 21);
            this.Radius_Label.TabIndex = 26;
            this.Radius_Label.Text = "Radius";
            this.Radius_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Radius_Trb
            // 
            this.Radius_Trb.Location = new System.Drawing.Point(220, 143);
            this.Radius_Trb.Maximum = 25;
            this.Radius_Trb.Minimum = 1;
            this.Radius_Trb.Name = "Radius_Trb";
            this.Radius_Trb.Size = new System.Drawing.Size(469, 45);
            this.Radius_Trb.TabIndex = 27;
            this.Radius_Trb.Value = 1;
            this.Radius_Trb.Scroll += new System.EventHandler(this.Radius_Trb_Scroll);
            // 
            // Threads_Trb
            // 
            this.Threads_Trb.Location = new System.Drawing.Point(220, 177);
            this.Threads_Trb.Maximum = 64;
            this.Threads_Trb.Minimum = 1;
            this.Threads_Trb.Name = "Threads_Trb";
            this.Threads_Trb.Size = new System.Drawing.Size(469, 45);
            this.Threads_Trb.TabIndex = 28;
            this.Threads_Trb.Value = 1;
            this.Threads_Trb.Scroll += new System.EventHandler(this.Threads_Trb_Scroll);
            // 
            // Radius_Tbx
            // 
            this.Radius_Tbx.Enabled = false;
            this.Radius_Tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Radius_Tbx.Location = new System.Drawing.Point(146, 143);
            this.Radius_Tbx.Margin = new System.Windows.Forms.Padding(2);
            this.Radius_Tbx.Name = "Radius_Tbx";
            this.Radius_Tbx.Size = new System.Drawing.Size(47, 21);
            this.Radius_Tbx.TabIndex = 29;
            this.Radius_Tbx.Text = "0";
            this.Radius_Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Original_Image_Label
            // 
            this.Original_Image_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Original_Image_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Original_Image_Label.Location = new System.Drawing.Point(119, 451);
            this.Original_Image_Label.Name = "Original_Image_Label";
            this.Original_Image_Label.Size = new System.Drawing.Size(150, 21);
            this.Original_Image_Label.TabIndex = 30;
            this.Original_Image_Label.Text = "Original image";
            this.Original_Image_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Converted_Image_Label
            // 
            this.Converted_Image_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Converted_Image_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Converted_Image_Label.Location = new System.Drawing.Point(475, 451);
            this.Converted_Image_Label.Name = "Converted_Image_Label";
            this.Converted_Image_Label.Size = new System.Drawing.Size(150, 21);
            this.Converted_Image_Label.TabIndex = 31;
            this.Converted_Image_Label.Text = "Converted image";
            this.Converted_Image_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(736, 575);
            this.Controls.Add(this.Converted_Image_Label);
            this.Controls.Add(this.Original_Image_Label);
            this.Controls.Add(this.Radius_Tbx);
            this.Controls.Add(this.Threads_Trb);
            this.Controls.Add(this.Radius_Trb);
            this.Controls.Add(this.Radius_Label);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ASM_ExeTime_Tbx);
            this.Controls.Add(this.C_ExeTime_Tbx);
            this.Controls.Add(this.ASM_ExeTime_Label);
            this.Controls.Add(this.C_ExeTime_Label);
            this.Controls.Add(this.Threads_Chkbx);
            this.Controls.Add(this.Threads_Tbx);
            this.Controls.Add(this.Threads_Label);
            this.Controls.Add(this.Convert_Btn);
            this.Controls.Add(this.DLL_Label);
            this.Controls.Add(this.Title_Label);
            this.Controls.Add(this.ASM_RadioBtn);
            this.Controls.Add(this.C_RadioBtn);
            this.Controls.Add(this.Saving_Path_Tbx);
            this.Controls.Add(this.Input_Picture_Box);
            this.Controls.Add(this.Saving_Path_Btn);
            this.Controls.Add(this.Loading_Path_Btn);
            this.Controls.Add(this.Loading_Path_Tbx);
            this.Controls.Add(this.Output_Picture_Box);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Output_Picture_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_Picture_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radius_Trb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Threads_Trb)).EndInit();
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
        private System.Windows.Forms.RadioButton C_RadioBtn;
        private System.Windows.Forms.RadioButton ASM_RadioBtn;
        private System.Windows.Forms.Label Title_Label;
        private System.Windows.Forms.Label DLL_Label;
        private System.Windows.Forms.Button Convert_Btn;
        private System.Windows.Forms.Label Threads_Label;
        private System.Windows.Forms.TextBox Threads_Tbx;
        private System.Windows.Forms.CheckBox Threads_Chkbx;
        private System.Windows.Forms.Label C_ExeTime_Label;
        private System.Windows.Forms.Label ASM_ExeTime_Label;
        private System.Windows.Forms.TextBox C_ExeTime_Tbx;
        private System.Windows.Forms.TextBox ASM_ExeTime_Tbx;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label Radius_Label;
        private System.Windows.Forms.TrackBar Radius_Trb;
        private System.Windows.Forms.TrackBar Threads_Trb;
        private System.Windows.Forms.TextBox Radius_Tbx;
        private System.Windows.Forms.Label Original_Image_Label;
        private System.Windows.Forms.Label Converted_Image_Label;
    }
}

