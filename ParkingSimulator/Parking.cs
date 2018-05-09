using System;
using System.Collections.Generic;

namespace ParkingSimulator
{
    internal class Parking
    {
        public List<Car> Cars { get; set; }

        public List<Transaction> Transactions { get; set; }

        public int Balance { get; set; }

        private static readonly Lazy<Parking> Lazy = new Lazy<Parking>(() => new Parking());
        public static Parking Instance => Lazy.Value;
        private Parking()
        {
            Cars = new List<Car>();
            Transactions = new List<Transaction>();
        }
    }
}
