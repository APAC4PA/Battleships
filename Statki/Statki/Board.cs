using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class Board
    {
        public char[,] board = { {' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' },
                         {'1', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                         {'2', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                         {'3', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                         {'4', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                         {'5', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                         {'6', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                         {'7', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                         {'8', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                         {'9', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                         {'0', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' } };



        public void ShowShipsBoard()
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(" "+board[i, j]+" ");
                }
                Console.WriteLine("");
            }
        }
        public void ShowStrikesBoard()
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(" "+board[i, j]+" ");
                }
                Console.WriteLine("");
            }
        }
    }
}