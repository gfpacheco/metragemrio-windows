using System;

namespace MetragemRio.Models
{
    class Meterage
    {
        public double timestamp { get; set; }
        public int status { get; set; }
        public double level { get; set; }
        public double precipitation { get; set; }
    }
}
