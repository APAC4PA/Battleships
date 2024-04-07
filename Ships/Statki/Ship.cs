using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class Ship
    {
        
        public void PresentShips(out int shipSelection)
        {
            shipSelection = 0;
            Console.WriteLine($"Your ships: Four: #");
            Console.WriteLine($"Your ships: Three: ##");
            Console.WriteLine($"Your ships: Two: ###");
            Console.WriteLine($"Your ships: One: ####");
        }
        public void InsertShips(out int x, out int y, out int shipSelection, out int rotationSelection)
        {
            shipSelection = 0;
            rotationSelection = 0;
            bool wrongOption = false;

            x = 0;
            y = 0;

            Console.WriteLine("Please select:   1 - horizontal    2 - vertical");
            do
            {
                if (wrongOption)
                {
                    Console.WriteLine("Wrong option");
                    Console.WriteLine("Please select:   1 - horizontal    2 - vertical");
                }
                rotationSelection = Convert.ToInt32(Console.ReadLine());
                wrongOption = true;
            }
            while (rotationSelection != 1 && rotationSelection != 2);
            wrongOption = false;

            Console.WriteLine("Please select ship");
            do
            {
                if (wrongOption)
                {
                    Console.WriteLine("Wrong option");
                    Console.WriteLine("Please select ship");
                }
                shipSelection = Convert.ToInt32(Console.ReadLine());
                wrongOption = true;
            }
            while (shipSelection != 1 && shipSelection != 2 && shipSelection != 3 && shipSelection != 4);
            wrongOption = false;
            do
            {
                if (wrongOption)
                {
                    Console.WriteLine("Wrong option");
                }
                Console.WriteLine("Column: ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Row: ");
                y = Convert.ToInt32(Console.ReadLine());
                wrongOption = true;
            }
            while (x > 10 || x < 1 || y > 10 || y < 1);
        }
    }
}
