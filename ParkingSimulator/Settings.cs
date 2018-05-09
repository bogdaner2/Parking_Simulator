using System;
using System.Collections.Generic;

namespace ParkingSimulator
{
    internal class Settings
    {

        public int Timeout { get; }
        public Dictionary<int,Car.CarType> Type { get; }
        public int ParkingPlace { get; }
        public int Fire { get; }

        private static readonly Lazy<Settings> Lazy = new Lazy<Settings>(() => new Settings());
        public static Settings Instance => Lazy.Value;
        private Settings()
        {
            
        }
    }
}
