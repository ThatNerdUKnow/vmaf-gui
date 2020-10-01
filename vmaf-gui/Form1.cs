using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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


            /*
            while ((line = p.StandardOutput.ReadLine()) != null)
            {
                output += line;
                Console.WriteLine(line);
            }*/
            //rtbConsole.Text += output;


            Console.WriteLine(program_name);
            Console.WriteLine(args);
            
            p.WaitForExit();
            //prgProgress.PerformStep();
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
            cmbResolution.SelectedIndex = 1;
            
            string[] models = Directory.GetFiles(".\\model");
            foreach (string model in models)
            {
                string safeName = model.Substring(8, model.Length - 8);
                if (!safeName.Contains(".model")&& safeName.Contains(".pkl"))
                {
                    cmbModel.Items.Add(safeName);
                }
            }
            try
            {
                cmbModel.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("There are no suitable models in the ./model folder");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prgProgress.Value = 0;
            
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
                    button1.Enabled = false;
                    if (!Directory.Exists("temp"))
                    {
                        Directory.CreateDirectory("temp");
                    }

                    string resolution = cmbResolution.Text;
                    string model = cmbModel.Text;
                    bool psnr = chkPSNR.Checked;
                    bool ssim = chkSSIM.Checked;

                    ThreadStart tStart = new ThreadStart(
                        () => {

                            //lblProgress.Text = "Decompressing Source...";
                            lblProgress.Invoke(new Action(delegate () { lblProgress.Text = "Decompressing Source..."; }));
                            decompressVideo(sourcePath, "./temp/source.yuv");
                            prgProgress.Invoke(new Action(delegate () { prgProgress.PerformStep(); }));

                            //lblProgress.Text = "Decompressing Compressed...";
                            lblProgress.Invoke(new Action(delegate () { lblProgress.Text = "Decompressing Compressed..."; }));

                            decompressVideo(compressedPath, "./temp/compressed.yuv");
                            prgProgress.Invoke(new Action(delegate () { prgProgress.PerformStep(); }));


                            vmaf(resolution, model, psnr, ssim);
                            prgProgress.Invoke(new Action(delegate () { prgProgress.PerformStep(); }));

                            ChildProcess("notepad", "log.xml", true);
                            prgProgress.Invoke(new Action(delegate () { prgProgress.PerformStep(); }));

                            lblProgress.Invoke(new Action(delegate () { lblProgress.Text = ""; }));
                            File.Delete("./temp/compressed.yuv");
                            File.Delete("./temp/source.yuv");

                            button1.Invoke(new Action(delegate () { button1.Enabled = true; }));

                        }

                        );


                    Thread t = new Thread(tStart);
                    t.Start();
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

        void vmaf(string resolution,string model,bool psnr,bool ssim)
        {
            string args = "yuv420p "+ resolution +" ./temp/source.yuv ./temp/compressed.yuv .\\model\\"+ model +" --log log.xml";
            if (chkPSNR.Checked)
            {
                args += " --psnr";
            }
            if (chkSSIM.Checked)
            {
                args += " --ssim";
            }

            //lblProgress.Text = "Performing VMAF...";
            lblProgress.Invoke(new Action(delegate () { lblProgress.Text = "Performing VMAF..."; }));

            ChildProcess("vmaf.exe",args ,false);

            
            
            
        }

        
    }

   
}
