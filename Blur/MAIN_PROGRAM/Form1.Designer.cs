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
            ((System.ComponentModel.ISupportInitialize)(this.Output_Picture_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_Picture_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // Output_Picture_Box
            // 
            this.Output_Picture_Box.Location = new System.Drawing.Point(369, 231);
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
            this.Input_Picture_Box.Location = new System.Drawing.Point(31, 231);
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
            this.C_RadioBtn.Location = new System.Drawing.Point(146, 145);
            this.C_RadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.C_RadioBtn.Name = "C_RadioBtn";
            this.C_RadioBtn.Size = new System.Drawing.Size(32, 17);
            this.C_RadioBtn.TabIndex = 12;
            this.C_RadioBtn.TabStop = true;
            this.C_RadioBtn.Text = "C";
            this.C_RadioBtn.UseVisualStyleBackColor = true;
            this.C_RadioBtn.CheckedChanged += new System.EventHandler(this.C_RadioBtn_CheckedChanged);
            // 
            // ASM_RadioBtn
            // 
            this.ASM_RadioBtn.AutoSize = true;
            this.ASM_RadioBtn.Location = new System.Drawing.Point(191, 145);
            this.ASM_RadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ASM_RadioBtn.Name = "ASM_RadioBtn";
            this.ASM_RadioBtn.Size = new System.Drawing.Size(48, 17);
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
            this.DLL_Label.Location = new System.Drawing.Point(31, 141);
            this.DLL_Label.Name = "DLL_Label";
            this.DLL_Label.Size = new System.Drawing.Size(98, 21);
            this.DLL_Label.TabIndex = 16;
            this.DLL_Label.Text = "DLL";
            this.DLL_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Convert_Btn
            // 
            this.Convert_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Convert_Btn.Location = new System.Drawing.Point(301, 426);
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
            this.Threads_Label.Location = new System.Drawing.Point(301, 141);
            this.Threads_Label.Name = "Threads_Label";
            this.Threads_Label.Size = new System.Drawing.Size(98, 21);
            this.Threads_Label.TabIndex = 18;
            this.Threads_Label.Text = "Threads";
            this.Threads_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Threads_Tbx
            // 
            this.Threads_Tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Threads_Tbx.Location = new System.Drawing.Point(418, 141);
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
            this.Threads_Chkbx.Location = new System.Drawing.Point(480, 144);
            this.Threads_Chkbx.Name = "Threads_Chkbx";
            this.Threads_Chkbx.Size = new System.Drawing.Size(98, 17);
            this.Threads_Chkbx.TabIndex = 20;
            this.Threads_Chkbx.Text = "Choose optimal";
            this.Threads_Chkbx.UseVisualStyleBackColor = true;
            this.Threads_Chkbx.CheckedChanged += new System.EventHandler(this.Threads_Chkbx_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(736, 537);
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
    }
}

