using System;

namespace ParkingSimulator
{
    internal static class Menu
    {
        private static Parking _parking = Parking.Instance;
        public static void GetMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Select an action and enter its number:\n" +
                                  "1)Add car \n" +
                                  "2)Remove car \n" +
                                  "3)Recharge car balance \n" +
                                  "4)Show transaction history for the last minute\n" +
                                  "5)Show Parking balance \n"+
                                  "6)Show count of free spots \n" +
                                  "7)Show Transactions.log\n" +
                                  "8)Show cars");
                int.TryParse(Console.ReadLine(),out int choise);
                switch (choise)
                {
                    case 1:
                        Console.Clear();
                        AddCar_Menu();
                        break;
                    case 6:
                        Console.Clear();
                        ShowFreeSpots_Menu();
                        break;         
                    case 8:
                        ShowCars_Menu();
                        break;
                    default:
                        throw new Exception("Incorrect data.Please,try it again");     
                }
                Console.WriteLine("Please, for exit enter ESCAPE and to continue - any other key ");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Environment.Exit(0);
        }

        private static void AddCar_Menu()
        {
            Console.WriteLine("Select car type:\n" +
                              "1)Passenger\n" +
                              "2)Truck \n" +
                              "3)Bus \n" +
                              "4)Motorcycle");
            int.TryParse(Console.ReadLine(), out int type);
            if(type < 1 || type > 4) { throw new Exception(); }
            Console.WriteLine("Input balance");
            int.TryParse(Console.ReadLine(), out int balance);
            Parking.Instance.AddCar(new Car(balance, (Car.CarType) Enum.Parse(typeof(Car.CarType), (type-1).ToString())));
        }

        private static void RemoveCar_Menu()
        {

        }

        private static void ShowFreeSpots_Menu()
        {
            Console.WriteLine(
                string.Format($"On parking {_parking.Cars.Count} cars | " +
                              $"Free spots : {_parking.Settings.ParkingPlace - _parking.Cars.Count}"));
        }

        private static void ShowCars_Menu()
        {
            foreach (var car in Parking.Instance.Cars)
            {
                Console.WriteLine(car.TypeOfTransport.ToString());
            }
        }
    }
}
