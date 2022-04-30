using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace vmaf_gui
{
    public partial class results : Form
    {
        public results()
        {
            InitializeComponent();
        }

        public void showResults(string path)
        {
            var doc = XDocument.Load(path);


            var frames = from frame in doc.Root.Descendants("frame")
                         select frame;

            

            foreach (var frame in frames)
            {
                double frameNum = double.Parse(frame.Attribute("frameNum").Value);
                double vmafScore = double.Parse(frame.Attribute("vmaf").Value);
                this.resultsChart.Series["VMAF"].Points.AddXY(frameNum, vmafScore);
            }

            //TODO Bind vmaf data to results form control
            
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void results_Load(object sender, EventArgs e)
        {

        }
    }
}
