using System;
using Tic_Tac_Toe.Classes;

namespace Tic_Tac_Toe
{
    public class Program
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


        /// <summary>
        /// PlayGame - Runs logic for a game of Tic-Tac-Toe. Calls to switch players, Get user position selections, Place Board markers,
        ///     Check for a winning condition, and checks for a draw condition.
        /// </summary>
        public static void PlayGame()
        {
            Console.Clear();
            bool gameFlag = true;

            while (gameFlag && avail.posCounter >= 0)
            {
                board.DisplayBoard();
                Player CurrentPlayer = GetPlayer();

                try
                {
                    Console.Write($"{CurrentPlayer.Name}'s move: ");

                    uint choice = avail.ChoosePosition(); //Retrieve User's selection

                    CurrentPlayer.moves.Append(choice.ToString()); //Record User's selection

                    board.PlaceMarker(choice, CurrentPlayer.Marker); //Place Marker on Board
                }
                catch (Exception)
                {
                    PlayGame();
                }


                if (CurrentPlayer.CheckForWin()) //Entered if Player has won
                {
                    Console.Clear();
                    Console.WriteLine($"{CurrentPlayer.Name} wins!");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    gameFlag = false;
                }
                else if(avail.posCounter == 0) //Entered if all positions are taken
                {
                    Console.Clear();
                    Console.WriteLine("Draw Game!");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    gameFlag = false;
                }
                else //Entered if Player has not won and positions are still available
                {
                    SwitchPlayer();
                    Console.Clear();
                }
            }
        }


        /// <summary>
        /// GetPlayer - Retrieves referance to current player whos isTurn value is true
        /// </summary>
        /// <returns> Player - Player whos turn it currently is </returns>
        public static Player GetPlayer()
        {
            Player current = (player1.IsTurn) ? player1 : player2; //Retrieve current player
            return current;
        }


        /// <summary>
        /// SwitchPlayer - Changes boolean value of Player's IsTurn property
        /// </summary>
        public static void SwitchPlayer()
        {
            player1.IsTurn = (player1.IsTurn) ? false : true; //Swap Bool Values
        }


        /// <summary>
        /// GetUserNames - Rerieves strings representing user's names
        /// </summary>
        public static void GetUserNames()
        {
            Console.Clear();
            Console.Write("\nPlayer One Name: ");
            player1.Name = Console.ReadLine();
            Console.Write("\nPlayer Two Name: ");
            player2.Name = Console.ReadLine();
        }


        /// <summary>
        /// GetMenuOption - Retrives integer value representing menu option choice
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Menu - Displays main menu options to user
        /// </summary>
        public static void Menu()
        {
            Console.WriteLine("1. Start New Game");
            Console.WriteLine("2. Exit");
        }
    }
}
