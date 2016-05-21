using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IK075G
{
    class ChartSeries
    {
        public string serieName { get; set; }
        public string serieDesc { get; set; }
        public bool serieSelected { get; set; }
        public string serieColor { get; set; }
        public string serieLineThickness { get; set; }

        public override string ToString()
        {
            return serieDesc;
        }
    }
}
