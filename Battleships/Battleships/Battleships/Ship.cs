using System;

namespace Battleships {
	internal class Ship {
		public void InsertShips(out int x, out int y, out int shipSelection, out int rotationSelection) {
			bool wrongOption = false;
			string xValue;
			x = 0;
			Console.WriteLine("Please select:   1 - horizontal    2 - vertical");
			do {
				if (wrongOption) {
					Console.WriteLine("Wrong option");
					Console.WriteLine("Please select:   1 - horizontal    2 - vertical");
				}
				rotationSelection = Convert.ToInt32(Console.ReadLine());
				wrongOption = true;
			}
			while (rotationSelection != 1 && rotationSelection != 2);
			wrongOption = false;

			Console.WriteLine("Please select ship");
			do {
				if (wrongOption) {
					Console.WriteLine("Wrong option");
					Console.WriteLine("Please select ship");
				}
				shipSelection = Convert.ToInt32(Console.ReadLine());
				wrongOption = true;
			}
			while (shipSelection != 1 && shipSelection != 2 && shipSelection != 3 && shipSelection != 4);
			wrongOption = false;
			do {
				if (wrongOption) {
					Console.WriteLine("Wrong option");
				}
				Console.WriteLine("A - J Column: ");
				xValue = Console.ReadLine();
				switch (xValue.ToUpper()) {
					case "A":
						x = 1;
						break;
					case "B":
						x = 2;
						break;
					case "C":
						x = 3;
						break;
					case "D":
						x = 4;
						break;
					case "E":
						x = 5;
						break;
					case "F":
						x = 6;
						break;
					case "G":
						x = 7;
						break;
					case "H":
						x = 8;
						break;
					case "I":
						x = 9;
						break;
					case "J":
						x = 10;
						break;
				}
				Console.WriteLine("1 - 10 Row: ");
				y = Convert.ToInt32(Console.ReadLine());
				wrongOption = true;
			}
			while (!Board.IsInBounds(x, y));
		}
	}
}
