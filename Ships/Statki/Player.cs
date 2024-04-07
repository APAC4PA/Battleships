using System;
using System.Collections.Generic;
using System.Data.Common;
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
        bool canPlaceShip = true;
        Ship SelectShips = new Ship();

        int[,] offsets = new int[,] {
            { -1, -1 }, { -1, 0 }, { -1, 1 },
            { 0, -1 }, { 0, 1 },
            { 1, -1 }, { 1, 0 }, { 1, 1 }
        };

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

                if (strikes.board[strikesY, strikesX] == 'X' || strikes.board[strikesY, strikesX] == '@')
                {
                    Console.WriteLine("This cell has already been hit. Enter other coordinates.");
                    wrongMove = true;
                }

            } while (wrongMove);

            if (board[strikesY, strikesX] == '#')
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
        public void PlaceShips(int GetShipSelection, int GetRotationSelection, int coordinateY, int coordinateX)
        {
            if (GetRotationSelection == 1)
            {
                if (GetShipSelection == 1)
                { 
                    if (boardShips.board[coordinateY, coordinateX] != 'O' && boardShips.board[coordinateY, coordinateX] != '#')
                    {
                        boardShips.board[coordinateY, coordinateX] = '#';

                        for (int offset = 0; offset < offsets.GetLength(0); offset++)
                        {
                            var k = coordinateY + offsets[offset, 0];
                            var l = coordinateX + offsets[offset, 1];

                            // Make sure cells aren't out of bounds
                            if (!(k >= 0 && k <= 10 && l >= 0 && l <= 10)) continue;

                            if (boardShips.board[k, l] != '.') continue;

                            boardShips.board[k, l] = 'O';
                        }
                    }
                    else
                    {
                        Console.WriteLine("You cannot place a ship in a space that contains another ship");
                        SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                    }
                }
                else if (GetShipSelection <= 4 && GetShipSelection > 1)
                {
                    if (coordinateX + GetShipSelection > 11)
                    {
                        Console.WriteLine("X exceeds the width of the board");
                        Console.WriteLine("Please enter a valid value");
                        SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                    }
                    else if (coordinateX <= 10 && coordinateX >= 1)
                    {

                        for (int j = 0; j < GetShipSelection; j++)
                        {
                            if (boardShips.board[coordinateY, coordinateX + j] == 'O' || boardShips.board[coordinateY, coordinateX + j] == '#')
                            {
                                canPlaceShip = false;
                                Console.WriteLine("You cannot place a ship on a space with an 'O'");
							}
                        }
                        if (!canPlaceShip)
                        {
							SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
						}

                        // surround the ship with 'O' to prevent placing another ship next to it
                        for (int j = 0; j < GetShipSelection; j++)
                        {
                            boardShips.board[coordinateY, coordinateX + j] = '#';

                            for (int offset = 0; offset < offsets.GetLength(0); offset++)
                            {
                                var k = coordinateY + offsets[offset, 0];
                                var l = coordinateX + j + offsets[offset, 1];

                                // Make sure cells aren't out of bounds
                                if (!(k >= 0 && k <= 10 && l >= 0 && l <= 10)) continue;

                                if (boardShips.board[k, l] != '.') continue;

                                boardShips.board[k, l] = 'O';
                            }
                        }
                    }
                }
            }
            // TODO: TO ZROB POZNIEJ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (GetRotationSelection == 2)
            {
                if (GetShipSelection == 1)
                {
                    if (boardShips.board[coordinateY, coordinateX] != 'O' && boardShips.board[coordinateY, coordinateX] != '#')
                    {
                        boardShips.board[coordinateY, coordinateX] = '#';

                        for (int offset = 0; offset < offsets.GetLength(0); offset++)
                        {
                            var k = coordinateY + offsets[offset, 0];
                            var l = coordinateX + offsets[offset, 1];

                            // Make sure cells aren't out of bounds
                            if (!(k >= 0 && k <= 10 && l >= 0 && l <= 10)) continue;

                            if (boardShips.board[k, l] != '.') continue;

                            boardShips.board[k, l] = 'O';
                        }
                    }
                    else
                    {
                        Console.WriteLine("You cannot place a ship in a space that contains another ship");
                        SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                    }
                }

                else if (GetShipSelection <= 4 && GetShipSelection > 1)
                {
                    if (coordinateY + GetShipSelection > 11)
                    {
                        Console.WriteLine("Y exceeds the width of the board");
                        Console.WriteLine("Please enter a valid value");
                        SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                    }
                    else if (coordinateX <= 10 && coordinateX >= 1)
                    {

                        for (int j = 0; j < GetShipSelection; j++)
                        {
                            if (boardShips.board[coordinateY, coordinateX + j] == 'O' || boardShips.board[coordinateY, coordinateX + j] == '#')
                            {
                                canPlaceShip = false;
                                Console.WriteLine("You cannot place a ship on a space with an 'O'");
                            }
                        }
                        if (!canPlaceShip)
                        {
                            SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                        }

                        // surround the ship with 'O' to prevent placing another ship next to it
                        for (int j = 0; j < GetShipSelection; j++)
                        {
                            boardShips.board[coordinateY + j, coordinateX] = '#';

                            for (int offset = 0; offset < offsets.GetLength(0); offset++)
                            {
                                var k = coordinateY + j + offsets[offset, 0];
                                var l = coordinateX + offsets[offset, 1];

                                // Make sure cells aren't out of bounds
                                if (!(k >= 0 && k <= 10 && l >= 0 && l <= 10)) continue;

                                if (boardShips.board[k, l] != '.') continue;

                                boardShips.board[k, l] = 'O';
                            }
                        }
                    }
                }
            }
        }
    }
}