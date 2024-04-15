using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
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
            int strikesX = 0;
            int strikesY = 0;

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
                string xValue = Console.ReadLine();
                switch (xValue.ToUpper())
                {
                    case "A":
                        strikesX = 1;
                        break;
                    case "B":
                        strikesX = 2;
                        break;
                    case "C":
                        strikesX = 3;
                        break;
                    case "D":
                        strikesX = 4;
                        break;
                    case "E":
                        strikesX = 5;
                        break;
                    case "F":
                        strikesX = 6;
                        break;
                    case "G":
                        strikesX = 7;
                        break;
                    case "H":
                        strikesX = 8;
                        break;
                    case "I":
                        strikesX = 9;
                        break;
                    case "J":
                        strikesX = 10;
                        break;
                }
                Console.WriteLine("Row: ");                                 //Ask for coordinates
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
            }                                                                   //Placing proper symbol
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
        public bool PlaceShips(int getShipSelection, int getRotationSelection, int coordinateY, int coordinateX)
        {
            bool wrongOption = false;

            if (getRotationSelection == 1)
            {
                if (getShipSelection == 1)
                {
                    if (boardShips.board[coordinateY, coordinateX] != 'O' && boardShips.board[coordinateY, coordinateX] != '#')
                    {
                        boardShips.board[coordinateY, coordinateX] = '#';

                        for (int offset = 0; offset < offsets.GetLength(0); offset++)
                        {
                            var verticalCoordinates = coordinateY + offsets[offset, 0];
                            var horizontalCoordinates = coordinateX + offsets[offset, 1];

                            // Make sure cells aren't out of bounds
                            if (!(verticalCoordinates >= 0 && verticalCoordinates <= 10 && horizontalCoordinates >= 0 && horizontalCoordinates <= 10)) continue;

                            if (boardShips.board[verticalCoordinates, horizontalCoordinates] != '.') continue;

                            boardShips.board[verticalCoordinates, horizontalCoordinates] = 'O';
                        }
                    }
                    else
                    {
                        Console.WriteLine("You cannot place a ship in a space that contains another ship");
                        SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                        wrongOption = true;
                    }
                }
                else if (getShipSelection <= 4 && getShipSelection > 1)
                {
                    if (coordinateX + getShipSelection > 11)
                    {
                        Console.WriteLine("X exceeds the width of the board");
                        Console.WriteLine("Please enter a valid value");
                        SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                        wrongOption = true;
                    }
                    else if (coordinateX <= 10 && coordinateX >= 1)
                    {

                        for (int j = 0; j < getShipSelection; j++)
                        {
                            if (boardShips.board[coordinateY, coordinateX + j] == 'O' || boardShips.board[coordinateY, coordinateX + j] == '#')
                            {
                                canPlaceShip = false;
                                Console.WriteLine("You cannot place a ship on a space with an 'O'");
                            }
                        }
                        if (!canPlaceShip)
                        {
                            SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                        }

                        // surround the ship with 'O' to prevent placing another ship next to it
                        for (int j = 0; j < getShipSelection; j++)
                        {
                            boardShips.board[coordinateY, coordinateX + j] = '#';

                            for (int offset = 0; offset < offsets.GetLength(0); offset++)
                            {
                                var verticalCoordinates = coordinateY + offsets[offset, 0];
                                var horizontalCoordinates = coordinateX + j + offsets[offset, 1];

                                // Make sure cells aren't out of bounds
                                if (!(verticalCoordinates >= 0 && verticalCoordinates <= 10 && horizontalCoordinates >= 0 && horizontalCoordinates <= 10)) continue;

                                if (boardShips.board[verticalCoordinates, horizontalCoordinates] != '.') continue;

                                boardShips.board[verticalCoordinates, horizontalCoordinates] = 'O';
                            }
                        }
                    }
                }
            }
            if (getRotationSelection == 2)
            {
                if (getShipSelection == 1)
                {
                    if (boardShips.board[coordinateY, coordinateX] != 'O' && boardShips.board[coordinateY, coordinateX] != '#')
                    {
                        boardShips.board[coordinateY, coordinateX] = '#';

                        for (int offset = 0; offset < offsets.GetLength(0); offset++)
                        {
                            var verticalCoordinates = coordinateY + offsets[offset, 0];
                            var horizontalCoordinates = coordinateX + offsets[offset, 1];

                            // Make sure cells aren't out of bounds
                            if (!(verticalCoordinates >= 0 && verticalCoordinates <= 10 && horizontalCoordinates >= 0 && horizontalCoordinates <= 10)) continue;

                            if (boardShips.board[verticalCoordinates, horizontalCoordinates] != '.') continue;

                            boardShips.board[verticalCoordinates, horizontalCoordinates] = 'O';
                        }
                    }
                    else
                    {
                        Console.WriteLine("You cannot place a ship in a space that contains another ship");
                        SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                        wrongOption = true;
                    }
                }

                else if (getShipSelection <= 4 && getShipSelection > 1)
                {
                    if (coordinateY + getShipSelection > 11)
                    {
                        Console.WriteLine("Y exceeds the width of the board");
                        Console.WriteLine("Please enter a valid value");
                        SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                        wrongOption = true;
                    }
                    else if (coordinateX <= 10 && coordinateX >= 1)
                    {

                        for (int j = 0; j < getShipSelection; j++)
                        {
                            if (boardShips.board[coordinateY + j, coordinateX] == 'O' || boardShips.board[coordinateY + j, coordinateX] == '#')
                            {
                                canPlaceShip = false;
                                Console.WriteLine("You cannot place a ship on a space with an 'O'");
                            }
                        }
                        if (!canPlaceShip)
                        {
                            SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                        }

                        // surround the ship with 'O' to prevent placing another ship next to it
                        for (int j = 0; j < getShipSelection; j++)
                        {
                            boardShips.board[coordinateY + j, coordinateX] = '#';

                            for (int offset = 0; offset < offsets.GetLength(0); offset++)
                            {
                                var verticalCoordinates = coordinateY + j + offsets[offset, 0];
                                var horizontalCoordinates = coordinateX + offsets[offset, 1];

                                // Make sure cells aren't out of bounds
                                if (!(verticalCoordinates >= 0 && verticalCoordinates <= 10 && horizontalCoordinates >= 0 && horizontalCoordinates <= 10)) continue;

                                if (boardShips.board[verticalCoordinates, horizontalCoordinates] != '.') continue;

                                boardShips.board[verticalCoordinates, horizontalCoordinates] = 'O';
                            }
                        }
                    }
                }
            }
        return wrongOption;
        }
    }
}
