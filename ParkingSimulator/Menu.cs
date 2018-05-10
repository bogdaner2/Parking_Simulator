﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

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
                    case 2:
                        Console.Clear();
                        RemoveCar_Menu();
                        break;
                    case 3:
                        Console.Clear();
                        RechargeBalance_Menu();
                        break;
                    case 4:
                        Console.Clear();
                        ShowLastMinuteLog_Menu();
                        break;
                    case 5:
                        Console.Clear();
                        ShowBalance_Menu();
                        break;                     
                    case 6:
                        Console.Clear();
                        ShowFreeSpots_Menu();
                        break;
                    case 7:
                        Console.Clear();
                        ShowLog_Menu();
                        break;
                    case 8:
                        Console.Clear();
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

        private static void ShowLastMinuteLog_Menu()
        {
            foreach (var transaction in _parking.Transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        private static void ShowLog_Menu()
        {
            using (StreamReader stream = new StreamReader("Transactions.log"))
            {
                var log = stream.ReadToEnd();
                Console.WriteLine(log);
            }
        }

        private static void ShowBalance_Menu()
        {
            Console.WriteLine("Parking balance: " + _parking.Balance);
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
            if (_parking.Settings.ParkingPlace > _parking.Cars.Count)
            {
                _parking.Cars.Add(
                    new Car(balance, 
                           (Car.CarType)Enum.Parse(typeof(Car.CarType),
                           (type - 1).ToString())));
            }
            else
            {
                Console.WriteLine("Maximum number of seats occupied");
            }
        }
        private static void RemoveCar_Menu()
        {
            Console.WriteLine("Select car number for remove:");
            ShowCars_Menu();
            CarSelection(out Car chosenCar);
            if (chosenCar.CarBalance < 0)
            {
                throw new Exception("Car balance is insufficient.Please recharge balance and try again");
            }
            _parking.Cars.Remove(chosenCar);
            Console.WriteLine("Car id: " +
                              chosenCar.Id.ToString()
                              .Substring(chosenCar.Id.ToString().Length - 5) +
                              " was removed");
        }
        private static void RechargeBalance_Menu()
        {
            Console.WriteLine("Choose car balance for recharging :");
            ShowCars_Menu();
            CarSelection(out Car chosenCar);
            Console.WriteLine("Input the amount of the replenishment");
            int.TryParse(Console.ReadLine(), out int amount);
            chosenCar.RechargeBalance(amount);
        }
        private static void ShowFreeSpots_Menu()
        {
            Console.WriteLine(
                string.Format($"On parking {_parking.Cars.Count} cars | " +
                              $"Free spots : {_parking.Settings.ParkingPlace - _parking.Cars.Count}"));
        }
        private static void ShowCars_Menu()
        {
            int itterator = 0;
            foreach (var car in _parking.Cars)
            {
                itterator++;
                Console.WriteLine($"{itterator}){car}");
            }
        }

        private static void CarSelection(out Car chosenCar)
        {
            int.TryParse(Console.ReadLine(), out int choise);
            if (choise <= 0 || choise > _parking.Cars.Count) { throw new Exception("There is no such number of сar.Please,try again"); }
            chosenCar = _parking.Cars[choise - 1];
        }

        public static void LoadCars() { }

        public static void SaveCars() { }

        public static void LoadSettings() { }
        
    }
}
