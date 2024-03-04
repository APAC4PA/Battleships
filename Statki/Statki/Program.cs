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
            char[,] board = new char[10, 10];
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
            bool canPlaceShip = true;
            int[] getNumberOfHits = new int[2] {0,0};
            int playAgain = 0;
            do
            {                  //Runda pierwszego gracza
                if (rounds <= 10)
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
                    for (int z = 0; z < GetShipSelection; z++)
                    {
                        Console.WriteLine($"x: {coordinateX}, y: {coordinateY}");
                        if (GetRotationSelection == 1)                                      //Jeżeli są ustawione poziomo
                        {
                            if (GetShipSelection == 1)
                            {

                                if (Player1.boardShips.board[coordinateY, coordinateX] != 'O' && Player1.boardShips.board[coordinateY, coordinateX] != '#')
                                {
                                    Player1.boardShips.board[coordinateY, coordinateX] = '#';

                                    for (int k = Math.Max(0, coordinateY - 1); k <= Math.Min(9, coordinateY + 1); k++)
                                    {
                                        for (int l = Math.Max(0, coordinateX - 1); l <= Math.Min(9, coordinateX + 1); l++)
                                        {
                                            if (Player1.boardShips.board[k, l] == '.')
                                            {
                                                Player1.boardShips.board[k, l] = 'O';
                                            }
                                        }
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
                                        if (Player1.boardShips.board[coordinateY, coordinateX + j] == 'O' && Player1.boardShips.board[coordinateY, coordinateX + j] == '#')
                                        {
                                            canPlaceShip = false;
                                            Console.WriteLine("You cannot place a ship on a space with an 'O'");
                                            SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                                        }
                                    }
                                    if (!canPlaceShip)
                                    {
                                        SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                                    }
                                    else
                                    {
                                        for (int j = 0; j < GetShipSelection; j++)
                                        {
                                            Player1.boardShips.board[coordinateY, coordinateX + j] = '#';
                                            for (int o = 0; o <= 10; o++)
                                            {
                                                for (int g = 0; g <= 10; g++)
                                                {
                                                    if (Player1.boardShips.board[o, g] == '#')
                                                    {
                                                        for (int k = o - 1; k <= o + 1; k++)
                                                        {
                                                            for (int l = g - 1; l <= g + 1; l++)
                                                            {
                                                                if (k >= 0 && k <= 10 && l >= 0 && l <= 10)
                                                                {
                                                                    if (Player1.boardShips.board[k, l] == '.')
                                                                    {
                                                                        Player1.boardShips.board[k, l] = 'O';
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (GetRotationSelection == 2)                                          //Jeżeli pionowo
                        {
                            if (GetShipSelection == 1)
                            {
                                if (Player1.boardShips.board[coordinateY, coordinateX] != 'O' && Player1.boardShips.board[coordinateY, coordinateX] != '#')
                                {
                                    Player1.boardShips.board[coordinateY, coordinateX] = '#';

                                    for (int k = Math.Max(0, coordinateY - 1); k <= Math.Min(9, coordinateY + 1); k++)
                                    {
                                        for (int l = Math.Max(0, coordinateX - 1); l <= Math.Min(9, coordinateX + 1); l++)
                                        {
                                            if (Player1.boardShips.board[k, l] == '.')
                                            {
                                                Player1.boardShips.board[k, l] = 'O';
                                            }
                                        }
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
                                canPlaceShip = true;

                                if (coordinateY + GetShipSelection > 11)
                                {
                                    Console.WriteLine("Y exceeds the height of the board");
                                    Console.WriteLine("Please enter a valid value");
                                    SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                                }
                                else if (coordinateY <= 10 && coordinateY >= 1)
                                {
                                    for (int j = 0; j < GetShipSelection; j++)
                                    {
                                        if (Player1.boardShips.board[coordinateY + j, coordinateX] == 'O' && Player1.boardShips.board[coordinateY + j, coordinateX] == 'O') 
                                        {
                                            canPlaceShip = false;
                                            Console.WriteLine("You cannot place a ship on a space with an 'O'");
                                            SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                                        }
                                    }

                                    if (canPlaceShip)
                                    {
                                        for (int j = 0; j < GetShipSelection; j++)
                                        {
                                            Player1.boardShips.board[coordinateY + j, coordinateX] = '#';
                                            for (int o = 0; o <= 10; o++)
                                            {
                                                for (int g = 0; g <= 10; g++)
                                                {
                                                    if (Player1.boardShips.board[o, g] == '#')
                                                    {
                                                        for (int k = o - 1; k <= o + 1; k++)
                                                        {
                                                            for (int l = g - 1; l <= g + 1; l++)
                                                            {
                                                                if (k >= 0 && k <= 10 && l >= 0 && l <= 10)
                                                                {
                                                                    if (Player1.boardShips.board[k, l] == '.')
                                                                    {
                                                                        Player1.boardShips.board[k, l] = 'O';
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                    Console.WriteLine("Your ships");
                    Player1.boardShips.ShowShipsBoard();
                    Console.ReadLine();
                    Console.Clear();
                    rounds++;
                }
                else if (rounds > 10 && rounds <= 20)
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
                    for (int z = 0; z < GetShipSelection; z++)
                    {
                        Console.WriteLine($"x: {coordinateX}, y: {coordinateY}");
                        if (GetRotationSelection == 1)                              //Jeżeli są ustawione poziomo GRACZ 2
                        {
                            if (GetShipSelection == 1)
                            {
                                if (Player2.boardShips.board[coordinateY, coordinateX] != 'O' && Player2.boardShips.board[coordinateY, coordinateX] != '#')
                                {
                                    Player2.boardShips.board[coordinateY, coordinateX] = '#';

                                    for (int k = Math.Max(0, coordinateY - 1); k <= Math.Min(9, coordinateY + 1); k++)
                                    {
                                        for (int l = Math.Max(0, coordinateX - 1); l <= Math.Min(9, coordinateX + 1); l++)
                                        {
                                            if (Player2.boardShips.board[k, l] == '.')
                                            {
                                                Player2.boardShips.board[k, l] = 'O';
                                            }
                                        }
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
                                        if (Player2.boardShips.board[coordinateY, coordinateX + j] == 'O' && Player2.boardShips.board[coordinateY, coordinateX + j] != '#')
                                        {
                                            canPlaceShip = false;
                                            Console.WriteLine("You cannot place a ship on a space with an 'O'");
                                            SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                                        }
                                    }
                                    if (!canPlaceShip)
                                    {
                                        SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                                    }
                                    else
                                    {
                                        for (int j = 0; j < GetShipSelection; j++)
                                        {
                                            Player2.boardShips.board[coordinateY, coordinateX + j] = '#';
                                            for (int o = 0; o <= 10; o++)
                                            {
                                                for (int g = 0; g <= 10; g++)
                                                {
                                                    if (Player2.boardShips.board[o, g] == '#')
                                                    {
                                                        for (int k = o - 1; k <= o + 1; k++)
                                                        {
                                                            for (int l = g - 1; l <= g + 1; l++)
                                                            {
                                                                if (k >= 0 && k <= 10 && l >= 0 && l <= 10)
                                                                {
                                                                    if (Player2.boardShips.board[k, l] == '.')
                                                                    {
                                                                        Player2.boardShips.board[k, l] = 'O';
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (GetRotationSelection == 2)                     //Jeżeli są ustawione pionowo GRACZ 2
                        {
                            if (GetRotationSelection == 2)
                            {
                                if (GetShipSelection == 1)
                                {
                                    if (Player2.boardShips.board[coordinateY, coordinateX] != 'O' && Player2.boardShips.board[coordinateY, coordinateX] != '#')
                                    {
                                        Player2.boardShips.board[coordinateY, coordinateX] = '#';

                                        for (int k = Math.Max(0, coordinateY - 1); k <= Math.Min(9, coordinateY + 1); k++)
                                        {
                                            for (int l = Math.Max(0, coordinateX - 1); l <= Math.Min(9, coordinateX + 1); l++)
                                            {
                                                if (Player2.boardShips.board[k, l] == '.')
                                                {
                                                    Player2.boardShips.board[k, l] = 'O';
                                                }
                                            }
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
                                    canPlaceShip = true;

                                    if (coordinateY + GetShipSelection > 11)
                                    {
                                        Console.WriteLine("Y przekracza wysokość planszy");
                                        Console.WriteLine("Please enter a valid value");
                                        SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                                    }
                                    else if (coordinateY <= 10 && coordinateY >= 1)
                                    {
                                        for (int j = 0; j < GetShipSelection; j++)
                                        {
                                            if (Player2.boardShips.board[coordinateY + j, coordinateX] == 'O' && Player2.boardShips.board[coordinateY + j, coordinateX] == 'O')
                                            {
                                                canPlaceShip = false;
                                                Console.WriteLine("You cannot place a ship on a space with an 'O'");
                                                SelectShips.InsertShips(out coordinateX, out coordinateY, out GetShipSelection, out GetRotationSelection);
                                            }
                                        }

                                        if (canPlaceShip)
                                        {
                                            for (int j = 0; j < GetShipSelection; j++)
                                            {
                                                Player2.boardShips.board[coordinateY + j, coordinateX] = '#';
                                                for (int o = 0; o <= 10; o++)
                                                {
                                                    for (int g = 0; g <= 10; g++)
                                                    {
                                                        if (Player2.boardShips.board[o, g] == '#')
                                                        {
                                                            for (int k = o - 1; k <= o + 1; k++)
                                                            {
                                                                for (int l = g - 1; l <= g + 1; l++)
                                                                {
                                                                    if (k >= 0 && k <= 10 && l >= 0 && l <= 10)
                                                                    {
                                                                        if (Player2.boardShips.board[k, l] == '.')
                                                                        {
                                                                            Player2.boardShips.board[k, l] = 'O';
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine("Your ships");
                    Player2.boardShips.ShowShipsBoard();
                    Console.ReadLine();
                    Console.Clear();
                    rounds++;
                }
                else
                {
                    if(rounds%2 == 1 && rounds > 20)
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
                                rounds = 1001;
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
                            rounds = 1001;
                        }
                        Console.ReadLine();
                        Console.Clear();
                        rounds++;
                    }
                }
            }
            while (rounds <= 1000);
            }
        }
    }