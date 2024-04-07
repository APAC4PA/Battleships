using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class Player
    {
        public Board boardShips = new Board();
        Board strikes = new Board();
        bool wrongMove;

        public bool PlayerStrikeShips(char[,] board)
        {
            int strikesX;
            int strikesY;

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(" " + strikes.board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Enter the cell you want to shoot at");
            do
            {
                Console.WriteLine("Column: ");
                strikesX = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Row: ");
                strikesY = Convert.ToInt32(Console.ReadLine());
                wrongMove = false;

                    if (strikesX < 0 || strikesX > 10 || strikesY < 0 || strikesY > 10)
                    {
                        Console.WriteLine("Invalid coordinates entered. Please re-enter.");
                        wrongMove = true;
                        continue;
                    }

                    if (strikes.board[strikesY,strikesX] == 'X' || strikes.board[strikesY, strikesX] == '@')
                    {
                        Console.WriteLine("This cell has already been hit. Enter other coordinates.");
                        wrongMove = true;
                    }

            } while (wrongMove);

            if (board[strikesY,strikesX] == '#')
            {
                strikes.board[strikesY, strikesX] = 'X';
                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        Console.Write(" " + strikes.board[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                return true;
            }
            else
            {
            strikes.board[strikesY, strikesX] = '@'; 
                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        Console.Write(" " + strikes.board[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                return false;
            }
        }
    }
}
