using System;

namespace ParkingSimulator
{
    internal class Transaction
    {
        public DateTime Time { get; }
        public Guid Id { get; }
        public double Fee { get; }

        public Transaction(Guid id,double fee)
        {
            Time = DateTime.Now;
            Id = id;
            Fee = fee;
        }

        public override string ToString()
        {
            return string.Format($"Car Id:{Id} | {Time} {Fee} ");
        }
    }
}
