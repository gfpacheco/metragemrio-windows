using System;

namespace MetragemRio.Models
{
    class Meterage
    {
        public double timestamp { get; set; }
        public string status { get; set; }
        public double level { get; set; }
        public Dams dams { get; set; }
    }
}
