using ChartComponent.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChartComponent.model
{
    public class RootModelDTO
    {
        public List<ChartModelDTO> Children { get; set; }
        public string ChartName { get; set; }
    }
}
