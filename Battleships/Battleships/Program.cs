using System;

namespace Battleships {
	internal class Program {

		static Ship SelectShips = new Ship();
		static Player Player1 = new Player("first");
		static Player Player2 = new Player("second");
		static int shipSize, shipRotation;
		static int coordinateX, coordinateY;

		static int rounds = 1;
		static int placingShips = 1;
		static int[] getNumberOfHits = new int[2] { 0, 0 };

		static void PlacingTurn(Player player) {
			Console.WriteLine($"It's the {player.name} player's turn");
			Console.WriteLine($"Placing round nr. {placingShips}");
			Console.WriteLine("Your ships");
			player.boardShips.ShowBoard();
			Console.WriteLine($" 1 - Single, how much is left |{player.shipsToPlace[0]}|");
			Console.WriteLine($" 2 - Double, how much is left |{player.shipsToPlace[1]}|");
			Console.WriteLine($" 3 - Triple, how much is left |{player.shipsToPlace[2]}|");
			Console.WriteLine($" 4 - Quadruple, how much is left |{player.shipsToPlace[3]}|");
			SelectShips.InsertShips(out coordinateX, out coordinateY, out shipSize, out shipRotation, player);
            Console.WriteLine($"x: {coordinateX}, y: {coordinateY}");
			if(player.PlaceShips(shipSize, shipRotation, coordinateY, coordinateX))
			{
				placingShips--;
			}
			Console.WriteLine("Your ships");
			player.boardShips.ShowBoard();
			Console.WriteLine("Press Enter");
			Console.ReadLine();
			Console.Clear();
			placingShips++;
		}

		static void ShootingTurn(Player player, Player other) {
			Console.WriteLine($"It's the {player.name} player's turn");
			Console.WriteLine("Ships");
			player.boardShips.ShowBoard();
			Console.WriteLine("Strikes");
			if (player.PlayerStrikeShips(other.boardShips.board)) {
				Console.WriteLine("Hit");
				Console.WriteLine("Extra turn");
				getNumberOfHits[0]++;
				Console.ReadLine();
				Console.Clear();
			} else {
				Console.WriteLine("Miss");
				Console.ReadLine();
				Console.Clear();
				Console.WriteLine("Press Enter");
    Console.WriteLine("Switch places with opponent");
				Console.ReadLine();
				rounds++;
			}
			player.boardShips.ShowBoard();
			if (getNumberOfHits[0] == 20) {
				Console.WriteLine("Winner");
                Console.ReadLine();
                rounds = -1;
			}
		}

		static void Main(string[] args) {

			while (rounds >= 0) {
				if (placingShips <= 10) {
					PlacingTurn(Player1);
				} else if (placingShips <= 20) {
					PlacingTurn(Player2);
if(placingShips > 20){
Console.Clear();
     Console.WriteLine("Press Enter");
     Console.WriteLine("Switch places with opponent");
     Console.ReadLine();
     Console.Clear();
}
				} else {
					if (rounds % 2 == 1) {
						ShootingTurn(Player1, Player2);
					} else {
						ShootingTurn(Player2, Player1);
					}
				}
			}
		}
	}
}
