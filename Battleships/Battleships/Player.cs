using System;

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

        public int[] shipsToPlace = { 4, 3, 2, 1 };

        public string name;
        public Player(string name)
        {
            this.name = name;
        }

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
            
            do
            {
wrongMove = false;
Console.WriteLine("Enter the cell you want to shoot at");
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
default:
wrongMove = true;
break;
                }
                Console.WriteLine("Row: ");                                 //Ask for coordinates
                strikesY = Convert.ToInt32(Console.ReadLine());
if(wrongMove == true){
Console.WriteLine("Invalid option");
}
                if (strikesY < 0 || strikesY > 10)
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
        public bool PlaceShips(int shipSize, int shipRotation, int coordinateY, int coordinateX)
        {
            if (shipRotation == 1)
            {
                if (shipSize == 1)
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
                            shipsToPlace[shipSize - 1]--;
                    }
                    else
                    {
                        Console.WriteLine("You cannot place a ship in a space that contains another ship");
                        //SelectShips.InsertShips(out coordinateX, out coordinateY, out shipSize, out shipRotation, this);
                        return true;
                    }
                }
                else if (shipSize <= 4 && shipSize > 1)
                {
                    if (coordinateX + shipSize > 11)
                    {
                        Console.WriteLine("X exceeds the width of the board");
                        //SelectShips.InsertShips(out coordinateX, out coordinateY, out shipSize, out shipRotation, this);
                        return true;
                    }
                    else if (coordinateX <= 10 && coordinateX >= 1)
                    {
                        for (int j = 0; j < shipSize; j++)
                        {
                            if (boardShips.board[coordinateY, coordinateX + j] == 'O' || boardShips.board[coordinateY, coordinateX + j] == '#')
                            {
                                canPlaceShip = false;
                                Console.WriteLine("You cannot place a ship on a space with an 'O'");
                                //SelectShips.InsertShips(out coordinateX, out coordinateY, out shipSize, out shipRotation, this);
                                return true;
                            }
                        }

                        if (!canPlaceShip)
                        {
                            //SelectShips.InsertShips(out coordinateX, out coordinateY, out shipSize, out shipRotation, this);
                        }

                        // surround the ship with 'O' to prevent placing another ship next to it
                        for (int j = 0; j < shipSize; j++)
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
                        shipsToPlace[shipSize - 1]--;
                    }
                }
            }
            if (shipRotation == 2)
            {
                if (shipSize == 1)
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
                        shipsToPlace[shipSize - 1]--;
                    }
                    else
                    {
                        Console.WriteLine("You cannot place a ship in a space that contains another ship");
                        //SelectShips.InsertShips(out coordinateX, out coordinateY, out shipSize, out shipRotation, this);
                        return true;
                    }
                }
                else if (shipSize <= 4 && shipSize > 1)
                {
                    if (coordinateY + shipSize > 11)
                    {
                        Console.WriteLine("Y exceeds the width of the board");
                        //SelectShips.InsertShips(out coordinateX, out coordinateY, out shipSize, out shipRotation, this);
                        return true;
                    }
                    else if (coordinateX <= 10 && coordinateX >= 1)
                    {

                        for (int j = 0; j < shipSize; j++)
                        {
                            if (boardShips.board[coordinateY + j, coordinateX] == 'O' || boardShips.board[coordinateY + j, coordinateX] == '#')
                            {
                                canPlaceShip = false;
                                Console.WriteLine("You cannot place a ship on a space with an 'O'");
                                //SelectShips.InsertShips(out coordinateX, out coordinateY, out shipSize, out shipRotation, this);
                                return true;
                            }
                        }
                        if (!canPlaceShip)
                        {
                            //SelectShips.InsertShips(out coordinateX, out coordinateY, out shipSize, out shipRotation, this);
                        }

                        // surround the ship with 'O' to prevent placing another ship next to it
                        for (int j = 0; j < shipSize; j++)
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
                        shipsToPlace[shipSize - 1]--;
                    }
                }
            }
            return false;
        }
    }
}
