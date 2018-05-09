using System;

namespace ParkingSimulator
{
    internal static class Menu
    {
        public static void GetMenu()
        {
            do
            {
                Console.WriteLine("Select an action and enter its number:\n" +
                                  "1)Add car \n" +
                                  "2)Remove car \n" +
                                  "3)Recharge car balance \n" +
                                  "4)Show transaction history for the last minute\n" +
                                  "5)Show Parking balance \n"+
                                  "6)Show count of free spots \n" +
                                  "7)Show Transactions.log");
                int.TryParse(Console.ReadLine(),out int choise);
                switch (choise)
                {
                   
                }
                Console.WriteLine("Please, for exit enter ESCAPE and to continue - any other key ");
            }   while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
