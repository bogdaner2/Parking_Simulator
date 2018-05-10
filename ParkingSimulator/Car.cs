using System;
using System.Collections;

namespace ParkingSimulator
{
    internal class Car 
    {
        public Guid Id { get; }
        public double CarBalance { get; set; }
        public CarType TypeOfTransport { get; }

        public Car(int balance,CarType type)
        {
            Id = Guid.NewGuid();
            CarBalance = balance;
            TypeOfTransport = type;
        }

        public enum CarType
        {
            Passenger,
            Truck,
            Bus,
            Motorcycle
        }

        public override string ToString()
        {
            string id = Id.ToString().Substring(Id.ToString().Length - 5);
            return string.Format($"Id:{id} Balance:{CarBalance} Type {TypeOfTransport}");
        }
    }
}
