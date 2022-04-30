using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

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


            // Spawn a child process. We don't need output from stdout so we don't capture it
            var p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = !show;
            p.StartInfo.FileName = program_name;
            p.StartInfo.Arguments = args;


            p.Start();


            // p.standardoutput is an input stream

            string output = "";

            Console.WriteLine(program_name);
            Console.WriteLine(args);

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

            //cmbResolution.SelectedIndex = 1;

            // Get list of model files and add them to the cmbModel form control
            string[] models = Directory.GetFiles(".\\model");
            foreach (string model in models)
            {
                string safeName = model.Substring(8, model.Length - 8);
                if (!safeName.Contains(".model") && safeName.Contains(".json"))
                {
                    // cmbModel.Items.Add(safeName);
                }
            }
            try
            {
                //cmbModel.SelectedIndex = 0;
            }
            catch
            {
                // Show message if no suitable model is found
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

                string sourcePath = "\"" + originalFileDialog.FileName + "\"";
                string compressedPath = "\"" + compressedFileDialog.FileName + "\"";

                Console.WriteLine(sourcePath);
                Console.WriteLine(compressedPath);
                try
                {
                    button1.Enabled = false;

                    // Create directory target for ffmpeg
                    if (!Directory.Exists("temp"))
                    {
                        Directory.CreateDirectory("temp");
                    }

                    // Get variables we need before we make a new thread
                    /* string resolution = cmbResolution.Text;
                     string model = cmbModel.Text;
                     bool psnr = chkPSNR.Checked;
                     bool ssim = chkSSIM.Checked;*/
                    string resolution = "";
                    string model = "";
                    bool psnr = false;
                    bool ssim = false;

                    // Define what functions the thread does
                    ThreadStart tStart = new ThreadStart(
                        () =>
                        {

                            // Decompress source video file
                            lblProgress.Invoke(new Action(delegate () { lblProgress.Text = "Decompressing Source..."; }));
                            decompressVideo(sourcePath, "./temp/source.y4m");
                            prgProgress.Invoke(new Action(delegate () { prgProgress.PerformStep(); }));

                            // Decompress compressed video file
                            lblProgress.Invoke(new Action(delegate () { lblProgress.Text = "Decompressing Compressed..."; }));
                            decompressVideo(compressedPath, "./temp/compressed.y4m");
                            prgProgress.Invoke(new Action(delegate () { prgProgress.PerformStep(); }));

                            // Start vmaf
                            vmaf(resolution, model, psnr, ssim);
                            prgProgress.Invoke(new Action(delegate () { prgProgress.PerformStep(); }));

                            // Show results in notepad
                            prgProgress.Invoke(new Action(delegate () { prgProgress.PerformStep(); }));
                            lblProgress.Invoke(new Action(delegate () { lblProgress.Text = "Done."; }));
                            ChildProcess("notepad", "log.xml", true);

                            results resultsForm = new results();
                            resultsForm.showResults("./log.xml");
                            resultsForm.ShowDialog();
                            

                            // Clean up form controls and delete .yuv files to save disk space
                            lblProgress.Invoke(new Action(delegate () { lblProgress.Text = ""; }));
                            File.Delete("./temp/compressed.yuv");
                            File.Delete("./temp/source.yuv");
                            button1.Invoke(new Action(delegate () { button1.Enabled = true; }));

                            

                        }

                        );

                    // Define the thread and start it
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

        void decompressVideo(string path, string output)
        {
            try
            {
                // Use ffmpeg to decompress the video into .yuv file
                ChildProcess("ffmpeg.exe", "-y -i " + path + " -pix_fmt yuv420p -vsync 0 " + output, false);
            }
            catch (Exception err)
            {
                MessageBox.Show(path, err.Message);
            }
        }

        void vmaf(string resolution, string model, bool psnr, bool ssim)
        {
            // Build arguments list for vmaf
            //string args = "yuv420p "+ resolution +" ./temp/source.yuv ./temp/compressed.yuv .\\model\\"+ model +" --log log.xml";
            Array res = resolution.Split(' ');

            string args = $"--threads 4 --reference ./temp/source.y4m --distorted ./temp/compressed.y4m -o log.xml";
            /*
            if (chkPSNR.Checked)
            {
                args += " --psnr";
            }
            if (chkSSIM.Checked)
            {
                args += " --ssim";
            }*/

            //lblProgress.Text = "Performing VMAF...";
            lblProgress.Invoke(new Action(delegate () { lblProgress.Text = "Performing VMAF..."; }));

            ChildProcess("vmaf.exe", args, false);




        }


    }


}
