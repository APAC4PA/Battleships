using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ship SelectShips = new Ship();
            Player Player1 = new Player();
            Player Player2 = new Player();
            int getShipSelection;
            int getRotationSelection;
            int coordinateX;
            int coordinateY;
            int[] numberOfSingle = new int[2] { 4, 4 };
            int[] numberOfDouble = new int[2] { 3, 3 };
            int[] numberOfTriple = new int[2] { 2, 2 };
            int[] numberOfQuadruple = new int[2] { 1, 1 };
            int rounds = 1;
            int placingShips = 1;
            bool isOptionInvalid;
            int[] getNumberOfHits = new int[2] { 0, 0 };
            do
            {                  
                if (placingShips <= 10)                                         //First player round
                {
                    Console.WriteLine("It's the first player's turn");
                    Console.WriteLine("Your ships");
                    Player1.boardShips.ShowBoard();
                    Console.WriteLine($" 1 - Single, how much is left |{numberOfSingle[0]}|");
                    Console.WriteLine($" 2 - Double, how much is left |{numberOfDouble[0]}|");
                    Console.WriteLine($" 3 - Triple, how much is left |{numberOfTriple[0]}|");
                    Console.WriteLine($" 4 - Quadruple, how much is left |{numberOfQuadruple[0]}|");
                    SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                    Console.WriteLine($"x: {coordinateX}, y: {coordinateY}");
                    isOptionInvalid = Player1.PlaceShips(getShipSelection, getRotationSelection, coordinateY, coordinateX);
                    if (getShipSelection == 4)
                    {
                        if(!isOptionInvalid)
                        {
                            if (numberOfQuadruple[0] > 0)
                            {
                                numberOfQuadruple[0]--;
                                placingShips++;
                            }
                            else
                            {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                            }
                        }
                    }
                    else if (getShipSelection == 3)
                    {
                        if (!isOptionInvalid)
                        {
                            if (numberOfTriple[0] > 0)
                            {
                                numberOfTriple[0]--;
                                placingShips++;
                            }
                            else
                            {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                            }
                        }
                    }
                    else if (getShipSelection == 2)
                    {
                        if (!isOptionInvalid)
                        {
                            if (numberOfDouble[0] > 0)
                            {
                                numberOfDouble[0]--;
                                placingShips++;
                            }
                            else
                            {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                            }
                        }
                    }
                    else if (getShipSelection == 1)
                    {
                        if (!isOptionInvalid)
                        {
                            if (numberOfSingle[0] > 0)
                            {
                                numberOfSingle[0]--;
                                placingShips++;
                            }
                            else
                            {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                            }
                        }
                    }
                    Player1.PlaceShips(getShipSelection, getRotationSelection, coordinateY, coordinateX);
                    Console.WriteLine("Your ships");
                    Player1.boardShips.ShowBoard();
                    Console.WriteLine($"You can place {9 - placingShips} more ship");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (placingShips > 10 && placingShips <= 20)
                {                                                                       //Second player round 
                    Console.WriteLine("It's the second player's turn");
                    Console.WriteLine("Your ships");
                    Player2.boardShips.ShowBoard();
                    Console.WriteLine($" 1 - Single, how much is left |{numberOfSingle[1]}|");
                    Console.WriteLine($" 2 - Double, how much is left |{numberOfDouble[1]}|");
                    Console.WriteLine($" 3 - Triple, how much is left |{numberOfTriple[1]}|");
                    Console.WriteLine($" 4 - Quadruple, how much is left |{numberOfQuadruple[1]}|");                  
                    SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                    Console.WriteLine($"x: {coordinateX}, y: {coordinateY}");
                    isOptionInvalid = Player2.PlaceShips(getShipSelection, getRotationSelection, coordinateY, coordinateX);
                    if (getShipSelection == 4)
                    {
                        if (!isOptionInvalid)
                        {
                            if (numberOfQuadruple[1] > 0)
                            {
                                numberOfQuadruple[1]--;
                                placingShips++;
                            }
                            else
                            {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                            }
                        }
                    }
                    else if (getShipSelection == 3)
                    {
                        if (!isOptionInvalid)
                        { 
                            if (numberOfTriple[1] > 0)
                            {
                                numberOfTriple[1]--;
                                placingShips++;
                            }
                            else
                            {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                            }
                        }
                    }
                    else if (getShipSelection == 2)
                    {
                        if (!isOptionInvalid)
                        {
                            if (numberOfDouble[1] > 0)
                            {
                                numberOfDouble[1]--;
                                placingShips++;
                            }
                            else
                            {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                            }
                        }
                    }
                    else if (getShipSelection == 1)
                    {
                        if (!isOptionInvalid)
                        {
                            if (numberOfSingle[1] > 0)
                            {
                                numberOfSingle[1]--;
                                placingShips++;
                            }
                            else
                            {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out getShipSelection, out getRotationSelection);
                            }
                        }
                    }
                    Player2.PlaceShips(getShipSelection, getRotationSelection, coordinateY, coordinateX);
                    Console.WriteLine("Your ships");
                    Player2.boardShips.ShowBoard();
                    Console.WriteLine($"You can place {20 - placingShips} more ship");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    if (rounds % 2 == 1)
                    {
                        Console.WriteLine("It's the first player's turn");
                        Console.WriteLine("Ships");
                        Player1.boardShips.ShowBoard();
                        Console.WriteLine("Strikes");
                        if (Player1.PlayerStrikeShips(Player2.boardShips.board))
                        {
                            Console.WriteLine("Hit");
                            Console.WriteLine("Extra turn");
                            getNumberOfHits[0]++;
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Miss");
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Press Enter");
                            Console.ReadLine();
                            rounds++;
                        }
                        Player1.boardShips.ShowBoard();
                        if (getNumberOfHits[0] == 20)
                        {
                            Console.WriteLine("Winner");
                            rounds = -1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("It's the first player's turn");
                        Console.WriteLine("Ships");
                        Player2.boardShips.ShowBoard();
                        Console.WriteLine("Strikes");
                        if (Player2.PlayerStrikeShips(Player1.boardShips.board))
                        {
                            Console.WriteLine("Hit");
                            Console.WriteLine("Extra turn");
                            getNumberOfHits[0]++;
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Miss");
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Press Enter");
                            Console.ReadLine();
                            rounds++;
                        }
                        Player2.boardShips.ShowBoard();
                        if (getNumberOfHits[1] == 20)
                        {
                            Console.WriteLine("Winner");
                            rounds = -1;
                        }
                    }
                }
            }
            while (rounds >= 0);
        }
    }
}