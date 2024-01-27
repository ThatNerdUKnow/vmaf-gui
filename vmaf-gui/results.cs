using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
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
            // Override culture of the current thread to possibly resolve locale issues with loading xml file
			CultureInfo culture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = culture;

			var doc = XDocument.Load(path);

            var frames = from frame in doc.Root.Descendants("frame")
                         select frame;

            double total = 0;
            foreach (var frame in frames)
            {
                double frameNum = double.Parse(frame.Attribute("frameNum").Value);
                double vmafScore = double.Parse(frame.Attribute("vmaf").Value);
                total += vmafScore;
                this.resultsChart.Series["VMAF"].Points.AddXY(frameNum, vmafScore);
            }

            double average = Math.Round(total / frames.ToArray().Length,2);

            label1.Text = "VMAF: " + average;
        }
    }
}
