using System;
using System.Collections.Generic;

namespace ParkingSimulator
{
    internal class Parking
    {
        public delegate void TransactionsRefreshHandler();
        public event TransactionsRefreshHandler onAddTransaction;

        private static readonly Lazy<Parking> Lazy = new Lazy<Parking>(() => new Parking());
        public static Parking Instance => Lazy.Value;
        public List<Car> Cars { get; }
        public List<Transaction> Transactions { get; set; }
        public double Balance { get; set; }
        public Settings Settings { get; }

        private Parking()
        {
            Cars = new List<Car>();
            Transactions = new List<Transaction>();
            onAddTransaction += Refresh;
            Balance = 0;
            Settings = Settings.Instance;
        }

        public void AddTransaction(Guid id , double fee)
        {
            Transactions.Add(new Transaction(id,fee));
            onAddTransaction?.Invoke();
        }

        private void Refresh()
        {
            Transactions.RemoveAll(x => (DateTime.Now - x.Time).TotalMinutes > 1);
        }
    }
}
