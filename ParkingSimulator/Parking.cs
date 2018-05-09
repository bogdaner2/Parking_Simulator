using System;
using System.Collections.Generic;

namespace ParkingSimulator
{
    internal class Parking
    {
        public List<Car> Cars { get; }
        public List<Transaction> Transactions { get; }
        public int Balance { get; set; }
        public Settings Settings { get; set; }

        private static readonly Lazy<Parking> Lazy = new Lazy<Parking>(() => new Parking());
        public static Parking Instance => Lazy.Value;
        private Parking()
        {
            Cars = new List<Car>();
            Transactions = new List<Transaction>();
        }

        public void AddCar(Car car)
        {
            Cars.Add(car);
        }
        public void RemoveCar(Car car)
        {
                Cars.Remove(car);
        }
    }
}
