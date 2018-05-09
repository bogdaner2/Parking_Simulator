using System.Collections.Generic;

namespace ParkingSimulator
{
    internal class Settings
    {
        public int Timeout { get; set; }
        public Dictionary<int,string> Type { get; set; }
        public int ParkingPlace { get; set; }
        public int Fire { get; set; }
    }
}
