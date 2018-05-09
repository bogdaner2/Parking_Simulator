using System;

namespace ParkingSimulator
{
    internal static class Menu
    {
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
                        AddCar_Menu();
                        break;
                    case 8:
                        ShowCars_Menu();
                        break;
                        
                }
                Console.WriteLine("Please, for exit enter ESCAPE and to continue - any other key ");
            }   while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void AddCar_Menu()
        {
            Console.WriteLine("Select car type:\n +" +
                              "1)Passenger\n" +
                              "2)Truck \n" +
                              "3)Bus \n" +
                              "4)Motorcycle");
            int.TryParse(Console.ReadLine(), out int type);
            Console.WriteLine("Input balance");
            int.TryParse(Console.ReadLine(), out int balance);
            Parking.Instance.AddCar(new Car(balance, (Car.CarType) Enum.Parse(typeof(Car.CarType), (type-1).ToString())));
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
