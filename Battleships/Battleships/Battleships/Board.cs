﻿using System;

namespace Battleships {
	internal class Board {


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

		public static bool IsInBounds(int x, int y) {
			return !(x > 10 || x < 1 || y > 10 || y < 1);
		}

		public void ShowBoard() {
			for (int y = 0; y < 11; y++) {
				for (int x = 0; x < 11; x++) {
					Console.Write(" " + board[y, x] + " ");
				}
				Console.WriteLine("");
			}
		}
	}
}
