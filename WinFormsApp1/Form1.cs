namespace WinFormsApp1
{
    using System;
    using System.Windows.Forms;
    using System.Windows.Media.TextFormatting;
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;

    public partial class Form1 : Form
    {
        public Form1()
        {
            using (StreamReader sr = new StreamReader("RotationSampleData.csv"))
            {
                this.InitializeComponent();
                var myModel = new PlotModel { Title = "Unix Time | Rotation" };
                var lines = new LineSeries();
                myModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = 1668729600, Maximum = 1668729660, MajorStep = 20, Title = "Unix Time" });
                myModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Rotation" });

                string[] read;
                string data;
                data = sr.ReadLine();

                while ((data = sr.ReadLine()) != null)
                {
                    read = data.Split(',', StringSplitOptions.None);
                    double x = double.Parse(read[0]);
                    double y = double.Parse(read[1]);
                    lines.Points.Add(new DataPoint(x, y));
                }
                
                myModel.Series.Add(lines);
                this.plot1.Model = myModel;
            }
        }
    }
}