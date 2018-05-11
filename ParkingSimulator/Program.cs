using System;
using System.Threading;

namespace ParkingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var parking = Parking.Instance;
            var earnedPerMinute = 0.0;
            var firstTick = true;
            parking.LoadCars();
            var timerLog = new Timer(
                e => parking.Log(ref earnedPerMinute,ref firstTick),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMinutes(1));
            var timerCharge = new Timer(
                e => parking.ChargeAFee(parking,ref earnedPerMinute),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(parking.Settings.Timeout));
            while (true)
            {
                try
                {
                    Menu.GetMenu();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please, enter any key for continue");
                    Console.ReadKey();
                }
            }
        }
    }
}


