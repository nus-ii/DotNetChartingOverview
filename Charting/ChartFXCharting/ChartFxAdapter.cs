﻿using System.Data;
using System.Drawing;

namespace FreeChartTools.Charting.ChartFXCharting
{

    public class ChartFxAdapter : BaseChartAdapter
    {
        public ChartFxAdapter(ChartParameters parameters)
            : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            var chart = new SoftwareFX.ChartFX.Lite.Chart
                {
                    Width = Parameters.ChartWidth,
                    Height = Parameters.ChartHeight
                };
            chart.Gallery = SoftwareFX.ChartFX.Lite.Gallery.Lines;            
            var result = new Bitmap(Parameters.ChartWidth, Parameters.ChartHeight);
            chart.DrawToBitmap(result, new Rectangle(0, 0, Parameters.ChartWidth, Parameters.ChartHeight));
            var ts = new DataTable();
            ts.Columns.Add(new DataColumn("x", typeof(int)));
            ts.Columns.Add(new DataColumn("y", typeof(int)));
            foreach (var pair in Parameters.SeriaData)
            {
                var row = ts.NewRow();
                row[0] = pair.Key;
                row[1] = pair.Value;
                ts.Rows.Add(row);
            }
            chart.RecalcScale();
            return result;
        }
    }
}