using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.ClientXF
{

    public class MainPageMDPMenuItem
    {
        public MainPageMDPMenuItem()
        {
            TargetType = typeof(MainPageMDPDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}