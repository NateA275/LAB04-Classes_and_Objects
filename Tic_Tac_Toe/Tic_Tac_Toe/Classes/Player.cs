﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe.Classes
{
    class Player
    {
        public string Name { get; set; }
        public char Marker { get; set; }
        public bool IsTurn { get; set; }
        public StringBuilder moves = new StringBuilder();

        public Player(char marker, bool isTurn)
        {
            Marker = marker;
            IsTurn = isTurn;
        }

        public bool CheckForWin()
        {
            string s = moves.ToString();

            string[,] sols = new string[,]
            {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" },
                {"1", "4", "7" },
                {"2", "5", "8" },
                {"3", "6", "9" },
                {"1", "5", "9" },
                {"3", "5", "7" },
            };


            for (int i = 0; i < sols.GetLength(0); i++)
            {
                if (s.Contains(sols[i, 0]) && s.Contains(sols[i, 1]) && s.Contains(sols[i, 2]))
                    return true;
            }

            return false;
        }
    }
}
