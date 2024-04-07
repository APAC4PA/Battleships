using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*char[,] board = new char[10, 10];*/
            Ship SelectShips = new Ship(); 
            Player Player1 = new Player();
            Player Player2 = new Player();
            int GetShipSelection;
            int GetRotationSelection;
            int coordinateX;
            int coordinateY;
            int[] numberOfSingle = new int[2] { 4, 4 };
            int[] numberOfDouble = new int[2] { 3, 3 };
            int[] numberOfTriple = new int[2] { 2, 2 };
            int[] numberOfQuadruple = new int[2] { 1, 1 };
            int rounds = 1;
            int placingShips = 1;
            int[] getNumberOfHits = new int[2] {0,0};
            do
            {                  //Runda pierwszego gracza
                if (placingShips <= 10)
                {
                    SelectShips.PresentShips(out GetShipSelection);
                    Console.WriteLine("It's the first player's turn");
                    Console.WriteLine("Your ships");
                    Player1.boardShips.ShowShipsBoard();
                    Console.WriteLine($"{numberOfSingle[0]} Single");
                    Console.WriteLine($"{numberOfDouble[0]} Double");
                    Console.WriteLine($"{numberOfTriple[0]} Triple");
                    Console.WriteLine($"{numberOfQuadruple[0]} Quadruple");
                    SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                    if (GetShipSelection == 4)
                    {
                        if (numberOfQuadruple[0] > 0)
                        {
                            numberOfQuadruple[0]--;
                        }
                        else
                        {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                        }
                    }
                    else if (GetShipSelection == 3)
                    {
                        if (numberOfTriple[0] > 0)
                        {
                            numberOfTriple[0]--;
                        }
                        else
                        {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                        }
                    }
                    else if (GetShipSelection == 2)
                    {
                        if (numberOfDouble[0] > 0)
                        {
                            numberOfDouble[0]--;
                        }
                        else
                        { 
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                        }
                    }
                    else if (GetShipSelection == 1)
                    {
                        if (numberOfSingle[0] > 0)
                        {
                            numberOfSingle[0]--;
                        }
                        else
                        {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                        }
                    }
                    Console.WriteLine($"x: {coordinateX}, y: {coordinateY}");
                    Player1.PlaceShips(GetShipSelection, GetRotationSelection, coordinateY, coordinateX);
                    Console.WriteLine("Your ships");
                    Player1.boardShips.ShowShipsBoard();
                    Console.ReadLine();
                    Console.Clear();
                    placingShips++;
                }
                else if (placingShips > 10 && placingShips <= 20)
                {
                    SelectShips.PresentShips(out GetShipSelection);                                        //Runda drugiego gracza
                    Console.WriteLine("It's the second player's turn");
                    Console.WriteLine("Your ships");
                    Player2.boardShips.ShowShipsBoard();
                    Console.WriteLine($"{numberOfSingle[1]} single");
                    Console.WriteLine($"{numberOfDouble[1]} double");
                    Console.WriteLine($"{numberOfTriple[1]} triple");
                    Console.WriteLine($"{numberOfQuadruple[1]} quadruple");
                    SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                    if (GetShipSelection == 4)
                    {
                        if (numberOfQuadruple[1] > 0)
                        {
                            numberOfQuadruple[1]--;
                        }
                        else
                        {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                        }
                    }
                    else if (GetShipSelection == 3)
                    {
                        if (numberOfTriple[1] > 0)
                        {
                            numberOfTriple[1]--;
                        }
                        else
                        {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                        }
                    }
                    else if (GetShipSelection == 2)
                    {
                        if (numberOfDouble[1] > 0)
                        {
                            numberOfDouble[1]--;
                        }
                        else
                        {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                        }
                    }
                    else if (GetShipSelection == 1)
                    {
                        if (numberOfSingle[1] > 0)
                        {
                            numberOfSingle[1]--;
                        }
                        else
                        {
                                Console.WriteLine("You no longer have such a ship");
                                SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                        }
                    }
                    Console.WriteLine($"x: {coordinateX}, y: {coordinateY}");
                    Player2.PlaceShips(GetShipSelection, GetRotationSelection, coordinateY, coordinateX);
                    Console.WriteLine("Your ships");
                    Player2.boardShips.ShowShipsBoard();
                    Console.ReadLine();
                    Console.Clear();
                    placingShips++;
                }
                else
                {
                    if(rounds%2 == 1)
                    {
                        Console.WriteLine("It's the first player's turn");
                        Player1.boardShips.ShowShipsBoard();
                        if (Player1.PlayerStrikeShips(Player2.boardShips.board))
                        {
                            Console.WriteLine("Hit");
                            Console.WriteLine("Extra turn");
                            getNumberOfHits[0] ++;
                            rounds--;
                        }
                        else
                        {
                        Console.WriteLine("Miss");
                        }
                        Player1.boardShips.ShowShipsBoard();
                        if (getNumberOfHits[0] == 20)
                            {
                                Console.WriteLine("Winner");
                                rounds = 101;
                            }
                        Console.ReadLine();
                        Console.Clear();
                        rounds++;
                    }
                    else
                    {
                        Console.WriteLine("It's the first player's turn");
                        Player2.boardShips.ShowShipsBoard();
                        if (Player2.PlayerStrikeShips(Player1.boardShips.board))
                        {
                            Console.WriteLine("Hit");
                            Console.WriteLine("Extra turn");
                            getNumberOfHits[1]++;
                            rounds--;
                        }
                        else
                        {
                            Console.WriteLine("Miss");
                        }
                        Player2.boardShips.ShowShipsBoard();
                        if (getNumberOfHits[1] == 20)
                        {
                            Console.WriteLine("Winner");
                            rounds = 101;
                        }
                        Console.ReadLine();
                        Console.Clear();
                        rounds++;
                    }
                }
            }
            while (rounds <= 100);
            }
        }
    }