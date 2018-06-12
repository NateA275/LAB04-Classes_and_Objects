using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe.Classes
{
    public class Positions
    {
        public StringBuilder positions = new StringBuilder();
        public int posCounter = 9;

        public uint ChoosePosition()
        {
            try
            {
                uint choice = Convert.ToUInt16(Console.ReadLine());

                if (positions.ToString().Contains(choice.ToString()))
                {
                    Console.WriteLine("That spot is not available.");
                    Console.Write("Try again: ");
                    choice = ChoosePosition();
                }
                if (choice < 1 || choice > 9)
                {
                    Console.WriteLine("Invalid Choice");
                    choice = ChoosePosition();
                }

                positions.Append(choice.ToString());
                posCounter--;
                return choice;
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please enter a remaining number.");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
                throw;
            }
        }
    }
}
