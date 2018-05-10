using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using ParkingSimulator;

namespace ParkingSimulator
{
    internal class Parking
    {
        private readonly ObservableCollection<Transaction> _transactions;
        private static readonly Lazy<Parking> Lazy = new Lazy<Parking>(() => new Parking());
        public static Parking Instance => Lazy.Value;
        public List<Car> Cars { get; }
        public ObservableCollection<Transaction> Transactions{ get { return _transactions; } }
        public double Balance { get; set; }
        public Settings Settings { get; }

        private Parking()
        {
            Cars = new List<Car>();
            _transactions = new ObservableCollection<Transaction>();
            _transactions.CollectionChanged += AddTransaction;
            Balance = 0;
            Settings = Settings.Instance;
        }

        private void AddTransaction(object sender, NotifyCollectionChangedEventArgs args)
        {
                ////Log
                //using (StreamWriter streamWriter = File.AppendText("Transactions.log"))
                //{
                //    Console.WriteLine(args.NewItems.ToString());
                //    //streamWriter.Write("\r\nLog Entry : ");
                //    //streamWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                //    //    DateTime.Now.ToLongDateString());
                //    //streamWriter.WriteLine("  :{0}",string.Format(""));
                //    //streamWriter.WriteLine("-------------------------------");
                //}
            foreach (var transaction in args.NewItems )
            {
                Console.WriteLine(transaction);
            }

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
    }
}
