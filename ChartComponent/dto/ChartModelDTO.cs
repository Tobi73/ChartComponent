using ChartComponent.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartComponent.dto
{
    public class ChartModelDTO: RootModelDTO
    {
        public List<Serie> SeriesList { get; set; }
        public string NameX { get; set; }
        public string NameY { get; set; }
        public List<string> AxisX { get; set; }
    }
}
