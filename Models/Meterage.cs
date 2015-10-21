using System;

namespace MetragemRio.Models
{
    class Meterage
    {
        public DateTime timestamp { get; set; }
        public Int32 status { get; set; }
        public Double level { get; set; }
        public Double precipitation { get; set; }
    }
}
