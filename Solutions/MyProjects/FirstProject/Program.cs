using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice; 
        static int flag = 0;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear(); 
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's Turn (O)");
                }
                else
                {
                    Console.WriteLine("Player 1's Turn (X)");
                }
                Console.WriteLine("\n");
                Board(); 
                choice = int.Parse(Console.ReadLine());

                
                if (board[choice] != 'X' && board[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        board[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        board[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine($"The row {choice} is already marked with {board[choice]}.");
                    Console.WriteLine("Please wait 2 seconds for the board to refresh...");
                    System.Threading.Thread.Sleep(2000);
                }
                flag = CheckWin();
            }
            while (flag != 1 && flag != -1);

            Console.Clear();
            Board(); 

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won!", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("The game is a draw.");
            }
            Console.ReadLine();
        }

        
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
            Console.WriteLine("     |     |      ");
        }

        
        private static int CheckWin()
        {
            #region Winning Conditions
            
            if (board[1] == board[2] && board[2] == board[3])
            {
                return 1;
            }
            else if (board[4] == board[5] && board[5] == board[6])
            {
                return 1;
            }
            else if (board[7] == board[8] && board[8] == board[9])
            {
                return 1;
            }
            // Vertical
            else if (board[1] == board[4] && board[4] == board[7])
            {
                return 1;
            }
            else if (board[2] == board[5] && board[5] == board[8])
            {
                return 1;
            }
            else if (board[3] == board[6] && board[6] == board[9])
            {
                return 1;
            }
            // Diagonal 
            else if (board[1] == board[5] && board[5] == board[9])
            {
                return 1;
            }
            else if (board[3] == board[5] && board[5] == board[7])
            {
                return 1;
            }
            #endregion

            // Checking for Draw
            else if (board[1] != '1' && board[2] != '2' && board[3] != '3' &&
                     board[4] != '4' && board[5] != '5' && board[6] != '6' &&
                     board[7] != '7' && board[8] != '8' && board[9] != '9')
            {
                return -1; // Draw
            }
            else
            {
                return 0; // Game is still ongoing
            }
        }
    }
}
