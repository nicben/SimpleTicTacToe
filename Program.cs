using System;

namespace SimpleTicTacToe
{
    class Program
    {
        char[,] board = {
                           {' ',' ',' '},
                           {' ',' ',' '},
                           {' ',' ',' '}
                       };
        static char player = 'X';
        static bool win;

        //--------------<Main>-----------
        static void Main(string[] args)
        {
            Console.Clear();
            Program obj = new Program();
            Console.WriteLine("Nytt spill!");
            int counter = 0;

            while (counter < 9)
            {
                obj.Print();
                obj.ValidateInput();
                win = obj.CheckWinner();
                if (win)
                {
                    break;
                }
                player = obj.ChangeTurn();

                counter++;
            }
            obj.Print();
            obj.PrintResult();

        }

        void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Spiller " + player + " sin tur");
            Console.WriteLine("-------------------");

            for (int row = 0; row < 3; row++)
            {
                Console.Write(" | ");

                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col] + " | ");
                }
                Console.WriteLine();
            }
        }


        void ValidateInput()
        {
            Console.WriteLine();
            Console.Write("Rad(1..3: ");
            int validPos = 3;
            int row = Convert.ToInt32(Console.ReadLine());

            while (row < 1 || row > 3)
            {
                Console.WriteLine("Ikke gyldig!");
                Console.Write("Rad(1..3): ");
                row = Convert.ToInt32(Console.ReadLine());
            }

            for (int rowCol = 0; rowCol < 3; rowCol++)
            {
                if (board[row - 1, rowCol] != ' ')
                {
                    validPos--;
                }
            }

            while (validPos == 0)
            {
                Console.WriteLine("Ikke gyldig!");
                Console.Write("Rad(1..3): ");
                row = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Kolonne(1..3: ");
            int col = Convert.ToInt32(Console.ReadLine());
            while (col < 1 || col > 3 || board[row - 1, col - 1] != ' ')
            {
                Console.WriteLine("Ikke gyldig!");
                Console.Write("Kolonne(1..3): ");
                col = Convert.ToInt32(Console.ReadLine());
            }

            row--;
            col--;

            board[row, col] = player;
        }

        char ChangeTurn()
        {
            if (player == 'X')
            {
                return '0';
            }
            else
            {
                return 'X';
            }
        }


        bool CheckWinner()
        {
            if (player == board[0, 0] && player == board[0, 1] && player == board[0, 2])
            {
                return true;
            }
            else if (player == board[1, 0] && player == board[1, 1] && player == board[1, 2])
            {
                return true;
            }
            else if (player == board[2, 0] && player == board[2, 1] && player == board[2, 2])
            {
                return true;
            }
            else if (player == board[0, 0] && player == board[1, 0] && player == board[2, 0])
            {
                return true;
            }
            else if (player == board[0, 1] && player == board[1, 1] && player == board[2, 1])
            {
                return true;
            }
            else if (player == board[0, 2] && player == board[1, 2] && player == board[2, 2])
            {
                return true;
            }
            else if (player == board[0, 0] && player == board[1, 1] && player == board[2, 2])
            {
                return true;
            }
            else if (player == board[0, 2] && player == board[1, 1] && player == board[2, 0])
            {
                return true;
            }
            return false;
        }

        void PrintResult()
        {
            if (win)
            {
                if (player == 'X')
                {
                    Console.WriteLine("Spiller X vant!");
                }
                else
                {
                    Console.WriteLine("Spiller 0 vant!");
                }
            }
            else
            {
                Console.WriteLine("Ingen vant!");
            }
        }

    }
}
