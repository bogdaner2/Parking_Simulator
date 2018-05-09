using System;
using System.Collections.Generic;

namespace ParkingSimulator
{
    internal class Parking
    {
        public List<Car> Cars { get; }
        public List<Transaction> Transactions { get; }
        public int Balance { get;}
        public Settings Settings { get; }

        private static readonly Lazy<Parking> Lazy = new Lazy<Parking>(() => new Parking());
        public static Parking Instance => Lazy.Value;
        private Parking()
        {
            Cars = new List<Car>();
            Transactions = new List<Transaction>();
            Balance = 0;
            Settings = Settings.Instance;
        }

        public void AddCar(Car car)
        {
            if (Settings.ParkingPlace > Cars.Count)
            {
                Cars.Add(car);
            }
            else {
                Console.WriteLine("Maximum number of seats occupied");
            }
        }
        public void RemoveCar(Car car)
        {
            Cars.Remove(car);
        }

        public void GetAmount()
        {
            Console.WriteLine(
                string.Format($"On parking {Cars.Count} cars | Free spots : {Settings.ParkingPlace - Cars.Count}"));
        }
    }
}
