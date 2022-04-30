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

            var pooled_metrics = from metric in doc.Root.Descendants("pooled_metrics")
                                 where metric.Attribute("name").Value == "vmaf"
                                 select metric;

           

            DataPointCollection data = null;
            foreach(var frame in frames)
            {
                double frameNum = double.Parse(frame.Attribute("frameNum").Value);
                double vmafScore = double.Parse(frame.Attribute("vmaf").Value);
                data.AddXY(frameNum, vmafScore);
                Console.WriteLine(frame);
            }
            
            //TODO Bind vmaf data to results form control
            
        }
    }
}
