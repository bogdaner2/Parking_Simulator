using System;
using System.Collections.Generic;

namespace ParkingSimulator
{
    internal class Settings
    {
        public int Timeout  => 3;
        public Dictionary<Car.CarType, int> Prices => new Dictionary<Car.CarType, int>
        {
            {Car.CarType.Truck, 5},
            {Car.CarType.Passenger, 3},
            {Car.CarType.Bus, 2},
            {Car.CarType.Motorcycle, 1}
        };
        public int ParkingPlace => 20;
        public double Fine => 0.3;
        private static readonly Lazy<Settings> Lazy = new Lazy<Settings>(() => new Settings());
        public static Settings Instance => Lazy.Value;
        private Settings() { }

    }
}
