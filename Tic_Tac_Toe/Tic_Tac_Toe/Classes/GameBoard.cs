using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe.Classes
{
    public class GameBoard
    {
        public char[] board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public void PlaceMarker(uint position, char marker)
        {
            board[--position] = marker;
        }


        /// <summary>
        /// DisplayBoard - Displays the game board in it's current state. 3x3 grid.
        /// </summary>
        public void DisplayBoard()
        {
            Console.WriteLine();
            Console.Write("\t");
            for (int i = 1; i <= board.Length; i++)
            {
                Console.Write($"|{board[i-1]}|");
                if (i % 3 == 0)
                {
                    Console.WriteLine();
                    Console.Write("\t");
                }
            }
            Console.WriteLine();
        }
    }
}
