using System;

namespace ParkingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var parking = Parking.Instance;
            parking.Balance = 500;
            Console.WriteLine(parking.Balance);
            Console.ReadLine(); 
        }
    }
}
