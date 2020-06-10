namespace Minecraft_Log_Reader
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
            this.outputbtn = new System.Windows.Forms.Button();
            this.outputlbl = new System.Windows.Forms.Label();
            this.inputlbl = new System.Windows.Forms.Label();
            this.inputbtn = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.FolderBrowserDialog();
            this.output = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // outputbtn
            // 
            this.outputbtn.Location = new System.Drawing.Point(12, 52);
            this.outputbtn.Name = "outputbtn";
            this.outputbtn.Size = new System.Drawing.Size(82, 37);
            this.outputbtn.TabIndex = 0;
            this.outputbtn.Text = "Output File";
            this.outputbtn.UseVisualStyleBackColor = true;
            this.outputbtn.Click += new System.EventHandler(this.outputbtn_Click);
            // 
            // outputlbl
            // 
            this.outputlbl.AutoSize = true;
            this.outputlbl.Location = new System.Drawing.Point(96, 63);
            this.outputlbl.Name = "outputlbl";
            this.outputlbl.Size = new System.Drawing.Size(61, 13);
            this.outputlbl.TabIndex = 1;
            this.outputlbl.Text = "Output File:";
            // 
            // inputlbl
            // 
            this.inputlbl.AutoSize = true;
            this.inputlbl.Location = new System.Drawing.Point(95, 25);
            this.inputlbl.Name = "inputlbl";
            this.inputlbl.Size = new System.Drawing.Size(79, 13);
            this.inputlbl.TabIndex = 3;
            this.inputlbl.Text = "Input Directory:";
            // 
            // inputbtn
            // 
            this.inputbtn.Location = new System.Drawing.Point(12, 12);
            this.inputbtn.Name = "inputbtn";
            this.inputbtn.Size = new System.Drawing.Size(82, 37);
            this.inputbtn.TabIndex = 2;
            this.inputbtn.Text = "Input Directory";
            this.inputbtn.UseVisualStyleBackColor = true;
            this.inputbtn.Click += new System.EventHandler(this.inputbtn_Click);
            // 
            // output
            // 
            this.output.DefaultExt = "*.txt";
            this.output.FileName = "C:\\";
            this.output.FileOk += new System.ComponentModel.CancelEventHandler(this.output_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 104);
            this.Controls.Add(this.inputlbl);
            this.Controls.Add(this.inputbtn);
            this.Controls.Add(this.outputlbl);
            this.Controls.Add(this.outputbtn);
            this.Name = "Form1";
            this.Text = "Minecraft Log Reader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button outputbtn;
        private System.Windows.Forms.Label outputlbl;
        private System.Windows.Forms.Label inputlbl;
        private System.Windows.Forms.Button inputbtn;
        private System.Windows.Forms.FolderBrowserDialog input;
        private System.Windows.Forms.SaveFileDialog output;
    }
}

