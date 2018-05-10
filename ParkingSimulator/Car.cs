﻿using System;

namespace ParkingSimulator
{
    internal class Car 
    {
        public Guid Id { get; }
        public double CarBalance { get;private set; }
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

        public void RechargeBalance(int count)
        {
            CarBalance += count;
            Console.WriteLine("Current balance : {0}",CarBalance);
        }

        public void Withdraw(double count)
        {
            CarBalance -= count;
        }

        public override string ToString()
        {
            string id = Id.ToString().Substring(Id.ToString().Length - 5);
            return string.Format($"Id:{id} Balance:{CarBalance} Type {TypeOfTransport}");
        }
    }
}
