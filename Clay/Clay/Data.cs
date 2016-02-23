using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clay
{
    public class Data
    {
        public partial class Datas
        {
            public int offset { get; set; }
            public int pressure { get; set; }
            public int layout { get; set; }
            public string component { get; set; }
            public string colorbound { get; set; }
            public string quality { get; set; }
            public string performance { get; set; }
            public int result { get; set; }
            public int timecode { get; set; }
            public string lot { get; set; }
            public DateTime date { get; set; }
        }
    }
}
