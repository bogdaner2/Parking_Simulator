using System;
using System.Collections.Generic;

namespace ParkingSimulator
{
    internal class Settings
    {

        public int Timeout { get; private set; }
        public Dictionary<Car.CarType,int> Prices { get; private set; }
        public int ParkingPlace { get; private set; }
        public double Fine { get; private set; }

        private static readonly Lazy<Settings> Lazy = new Lazy<Settings>(() => new Settings());
        public static Settings Instance => Lazy.Value;
        private Settings() { }

        public void SetSettings(int timeout,int parkingplace,Dictionary<Car.CarType,int> prices,double fine)
        {
            Timeout = timeout;
            Prices = prices;
            ParkingPlace = parkingplace;
            Fine = fine;
        }
    }
}
