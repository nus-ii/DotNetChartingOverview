﻿using System.Drawing;
using System.Globalization;
using System.Linq;
using ChartingCore;
using WebChart;

namespace FreeChartTools.FreeCharting.WebCharting
{
    /// <summary>
    /// BSD License 
    /// Official link - http://www.carlosag.net/tools/webchart/
    /// </summary>
    public class WebChartAdapter : BaseChartAdapter
    {
        public WebChartAdapter(ChartParameters parameters)
            : base(parameters)
        {
        }

        private ChartPointCollection GenerateChartPointCollection()
        {
            return new ChartPointCollection(Parameters.SeriaData.Select(point => new ChartPoint(point.Key.ToString(CultureInfo.InvariantCulture), point.Value)).ToArray());
        }

        protected override Image DoCreateChartImage()
        {
            var webChart = new LineChart(GenerateChartPointCollection());
            webChart.Engine = new ChartEngine {Size = new Size(Parameters.ChartWidth, Parameters.ChartHeight)};
            webChart.Engine.Charts = new ChartCollection(webChart.Engine) {webChart};
            return webChart.Engine.GetBitmap();
        }
    }
}