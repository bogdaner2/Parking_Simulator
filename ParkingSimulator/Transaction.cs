using System;

namespace ParkingSimulator
{
    internal class Transaction
    {
        public DateTime Time { get; set; }
        public Guid Id { get; set; }
        public int Fee { get; set; }

        public Transaction(Guid id,int fee)
        {
            Time = DateTime.Now;
            Id = id;
            Fee = fee;
        }
    }
}
