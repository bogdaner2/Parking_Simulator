using System;
using System.Collections;

namespace ParkingSimulator
{
    internal class Car 
    {
        public Guid Id { get; set; }
        public int CarBalance { get; set; }
        public CarType TypeOfTransport { get; set; }

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
    }
}
