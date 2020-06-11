using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Text.RegularExpressions;

namespace Minecraft_Log_Reader
{
    public partial class Progress : Form
    {
        public Boolean censorIPS;
        public Progress(Boolean ipcensor)
        {
            InitializeComponent();
            censorIPS = ipcensor;
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
            if (input.SelectedPath != "" && output.FileName != "C:\\\\")
            {
                if (System.IO.Directory.Exists(input.SelectedPath))
                {
                    int i = 0;
                    foreach (String path in System.IO.Directory.GetFiles(input.SelectedPath))
                    {
                        if (path.ToLower().EndsWith(".log.gz"))
                        {
                            this.progressBar1.Maximum = System.IO.Directory.GetFiles(input.SelectedPath).Length;
                            byte[] file = File.ReadAllBytes(@path);
                            byte[] decompressed = Decompress(file);
                            this.progressBar1.Value = i;
                            if (!censorIPS)
                            {
                                lines.Add(System.Text.Encoding.Default.GetString(decompressed));
                            } else
                            {
                                String clean = Regex.Replace(System.Text.Encoding.Default.GetString(decompressed), "\\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\b", "192.168.0.100");
                                lines.Add(clean);
                            }
                        }
                        i++;
                    }
                }
            }
            if (lines.Count > 0)
            {
                File.WriteAllLines(this.output.FileName, lines.ToArray());
                MessageBox.Show("Completed!");
                this.Dispose();
            }
            else
            {
                this.Dispose();
            }
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            this.Visible = true;
            this.Activate();
            output.ShowDialog();
            input.ShowDialog();
            logs();
        }
    }
}
