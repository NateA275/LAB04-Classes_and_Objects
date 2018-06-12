using System;
using Tic_Tac_Toe.Classes;

namespace Tic_Tac_Toe
{
    class Program
    {

        public static Player player1;
        public static Player player2;
        public static Positions avail;
        public static GameBoard board;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Tic-Tac_Toe game!");
            Console.WriteLine("Select an option below to get started.\n");
            bool runFlag = true;

            while (runFlag)
            {
                try
                {
                    Menu();
                    int choice = GetMenuOption();
                    switch (choice)
                    {
                        case 1:
                            player1 = new Player('X', true);
                            player2 = new Player('O', false);
                            avail = new Positions();
                            board = new GameBoard();
                            GetUserNames();
                            PlayGame();
                            break;
                        case 2:
                            runFlag = false;
                            break;
                    }
                }
                catch (Exception)
                {
                }
            }
            Console.Clear();
            Console.WriteLine("Thanks for Playing!");
            Console.ReadLine();
        }


        public static void PlayGame()
        {
            Console.Clear();
            bool gameFlag = true;

            while (gameFlag && avail.posCounter >= 0)
            {
                board.DisplayBoard();
                Player current = (player1.IsTurn) ? player1 : player2;


                try
                {
                    Console.Write($"{current.Name}'s move: ");
                    uint choice = avail.ChoosePosition();
                    current.moves.Append(choice.ToString());
                    board.PlaceMarker(choice, current.Marker);
                }
                catch (Exception)
                {
                    PlayGame();
                }


                if (current.CheckForWin())
                {
                    Console.Clear();
                    Console.WriteLine($"{current.Name} wins!");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    gameFlag = false;
                }
                else if(avail.posCounter == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Draw Game!");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    gameFlag = false;
                }
                else
                {
                    player1.IsTurn = (player1.IsTurn) ? false : true;
                    Console.Clear();
                }
            }
        }

        public static void GetUserNames()
        {
            Console.Clear();
            Console.Write("\nPlayer One Name: ");
            player1.Name = Console.ReadLine();
            Console.Write("\nPlayer Two Name: ");
            player2.Name = Console.ReadLine();
        }

        public static int GetMenuOption()
        {
            try
            {
                int userChoice = Convert.ToInt16(Console.ReadLine());
                if (userChoice < 1 || userChoice > 2)
                {
                    Console.WriteLine("That is not an option");
                    userChoice = GetMenuOption();
                }
                return userChoice;
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid Input");
                throw;
            }
        }

        public static void Menu()
        {
            Console.WriteLine("1. Start New Game");
            Console.WriteLine("2. Exit");
        }
    }
}
