using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.IO.Compression;

namespace Minecraft_Log_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        static byte[] Decompress(byte[] gzip)
        {
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            using (GZipStream stream = new GZipStream(new MemoryStream(gzip),
                CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }

        private void logs()
        {
            List<String> lines = new List<String>();
            if(input.SelectedPath != "" && output.FileName != "C:\\")
            {
                if (System.IO.Directory.Exists(input.SelectedPath))
                {
                    foreach(String path in System.IO.Directory.GetFiles(input.SelectedPath))
                    {
                        if (path.ToLower().EndsWith(".log.gz"))
                        {
                            byte[] file = File.ReadAllBytes(@path);
                            byte[] decompressed = Decompress(file);
                            lines.Add(System.Text.Encoding.Default.GetString(decompressed));
                        }
                    }
                }
            }
            if(lines.Count > 0)
            {
                File.WriteAllLines(this.output.FileName, lines.ToArray());
            } else
            {
                //MessageBox.Show("No compressed logs were found. Did you select the correct directory?", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void inputbtn_Click(object sender, EventArgs e)
        {

            DialogResult input = this.input.ShowDialog();
            if(input == DialogResult.OK && !string.IsNullOrWhiteSpace(this.input.SelectedPath))
            {
                this.inputlbl.Text = "Input Directory: " + this.input.SelectedPath;
                logs();
            } else
            {
                MessageBox.Show("Folder was corrupted or invalid. Did you select a working folder?",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void outputbtn_Click(object sender, EventArgs e)
        {
            output.ShowDialog();
        }

        private void output_FileOk(object sender, CancelEventArgs e)
        {
            outputlbl.Text = "Output File: " + output.FileName;
            logs();
        }
    }
}
