using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chartTest.Controllers
{
    public class ChartHelper
    {
        public static Chart CreateDummyChart()
        {
            var chart = new Chart() { Width = 600, Height = 400 };
            chart.Palette = ChartColorPalette.Excel;
            chart.Legends.Add(new Legend("legend1") { Docking = Docking.Bottom });

            var title = new Title("Test chart", Docking.Top, new Font("Arial", 15, FontStyle.Bold), Color.Brown);
            chart.Titles.Add(title);
            chart.ChartAreas.Add("Area 1");

            chart.Series.Add("Series 1");
            chart.Series.Add("Series 2");

            chart.BackColor = Color.Azure;
            var random = new Random();

            //add random data: series 1
            foreach (int value in new List<int>() { random.Next(100), random.Next(100), random.Next(100), random.Next(100) })
            {
                chart.Series["Series 1"].Points.AddY(value);

                //attach JavaScript events - it can also be ajax call
                chart.Series["Series 1"].Points.Last().MapAreaAttributes = "onclick=\"alert('value: #VAL, series: #SER');\"";
            }

            //add random data: series 2
            foreach (int value in new List<int>() { random.Next(100), random.Next(100), random.Next(100), random.Next(100) })
            {
                chart.Series["Series 2"].Points.AddY(value);

                //attach JavaScript events - it can also be ajax call
                chart.Series["Series 2"].Points.Last().MapAreaAttributes = "onclick=\"alert('value: #VAL, series: #SER');\"";
            }

            return chart;
        }
    }
}