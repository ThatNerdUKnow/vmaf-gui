using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace vmaf_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        string ChildProcess(string program_name, string args, bool show)
        {

            
            // Spawn a child process, record stdout and return it
            var p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = !show;
            p.StartInfo.FileName = program_name;
            p.StartInfo.Arguments = args;

            p.Start();

            // p.standardoutput is an input stream
            //string output = p.StandardOutput.ReadToEnd();
            string output = "";
            string line;

            
            while ((line = p.StandardOutput.ReadLine()) != null)
            {
                output += line;
                
            }
            //rtbConsole.Text += output;

       
            p.WaitForExit();
            
            return output;
        }

        private void btnCompressed_Click(object sender, EventArgs e)
        {
            compressedFileDialog.ShowDialog();
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            originalFileDialog.ShowDialog();
        }

        private void originalFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string source = originalFileDialog.SafeFileName;
            lblSource.Text = source;
        }

        private void compressedFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string compressed = compressedFileDialog.SafeFileName;
            lblCompressed.Text = compressed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbResolution.Text = "1920 1080";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                originalFileDialog.OpenFile();
                compressedFileDialog.OpenFile();

                originalFileDialog.Dispose();
                compressedFileDialog.Dispose();

                string sourcePath ="\""+ originalFileDialog.FileName + "\"";
                string compressedPath = "\"" + compressedFileDialog.FileName + "\"";

                Console.WriteLine(sourcePath);
                Console.WriteLine(compressedPath);
                try
                {
                    if (!Directory.Exists("temp"))
                    {
                        Directory.CreateDirectory("temp");
                    }

                    
                    decompressVideo(sourcePath,"./temp/source.yuv");
                   
                    decompressVideo(compressedPath,"./temp/compressed.yuv");

                    vmaf();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            catch
            {
                MessageBox.Show("You must select both an original file and a compressed file to compare");
            }
        }

        void decompressVideo(string path,string output)
        {
            try
            {
                ChildProcess("ffmpeg.exe", "-y -i " + path + " -pix_fmt yuv420p -vsync 0 "+ output,false);
            }
            catch (Exception err)
            {
                MessageBox.Show(path, err.Message);
            }
        }

        void vmaf()
        {
            string args = "yuv420p "+ cmbResolution.Text +" ./temp/source.yuv ./temp/compressed.yuv ./model/vmaf_v0.6.1.pkl --log log.xml";
            if (chkPSNR.Checked)
            {
                args += " --psnr";
            }
            if (chkSSIM.Checked)
            {
                args += " --ssim";
            }
            ChildProcess("vmaf.exe",args ,false);

            
            ChildProcess("notepad", "log.xml",true);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

   
}
