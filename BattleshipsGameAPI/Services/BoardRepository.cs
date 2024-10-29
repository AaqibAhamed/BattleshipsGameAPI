using BattleshipsGameAPI.Models;
using static BattleshipsGameAPI.Models.Ship;

namespace BattleshipsGameAPI.Services
{
    public class BoardRepository : IBoardRepository
    {
        public char[,] grid;
        public Ship[] ships;
       // public Ship shipPosition;

        public BoardRepository()
        {
            grid = new char[10, 10];
            ships = new Ship[3]; // 1 Battleship + 2 Destroyers
            InitializeGrid();
        }

        public void InitializeGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j] = '~'; // Water
                }
            }
        }

        public void PlaceShips()
        {
            ships[0] = new Ship(ShipType.Battleship);
            ships[1] = new Ship(ShipType.Destroyer);
            ships[2] = new Ship(ShipType.Destroyer);

            Random rand = new Random();
            foreach (var ship in ships)
            {
                bool placed = false;
                while (!placed)
                {
                    int row = rand.Next(0, 10);
                    int col = rand.Next(0, 10);
                    bool horizontal = rand.Next(0, 2) == 0;

                    placed = PlaceShip(ship, row, col, horizontal);
                }
            }
        }

        public bool PlaceShip(Ship ship, int row, int col, bool horizontal)
        {
            if (horizontal)
            {
                if (col + ship.Size > 10) return false;

                for (int i = 0; i < ship.Size; i++)
                {
                    if (grid[row, col + i] != '~') return false;
                }

                for (int i = 0; i < ship.Size; i++)
                {
                    grid[row, col + i] = ship.Symbol;
                }
            }
            else
            {
                if (row + ship.Size > 10) return false;

                for (int i = 0; i < ship.Size; i++)
                {
                    if (grid[row + i, col] != '~') return false;
                }

                for (int i = 0; i < ship.Size; i++)
                {
                    grid[row + i, col] = ship.Symbol;
                }
            }

           //string? position = shipPosition?.GetShipPosition(ship);
           
           //Console.WriteLine(position);

            return true;
        }

        public (bool,string) ProcessShot(string input)
        {
            int row = input[0] - 'A';
            int col = int.Parse(input.Substring(1)) - 1;
            var message = "";

            if (row < 0 || row >= 10 || col < 0 || col >= 10)
            {
                message = "Invalid Input";
                return (false, message);
            }                          

            if (grid[row, col] == '~')
            {
                grid[row, col] = 'O'; // Miss
                message = "Missed!";
                Console.WriteLine("Missed!");
            }
            else if (grid[row, col] == 'B' || grid[row, col] == 'D')
            {
                char symbol = grid[row, col];
                grid[row, col] = 'X'; // Hit
                message = "Hit!";
                Console.WriteLine("Hit!");

                foreach (var ship in ships)
                {
                    if (ship.Symbol == symbol && ship.Hit())
                    {
                        message = $"{ship.Type} sunk!";
                        Console.WriteLine($"{ship.Type} sunk!");
                        break;
                    }
                }
            }

            return (true, message);
        }

        public bool AllShipsSunk()
        {
            foreach (var ship in ships)
            {
                if (!ship.IsSunk()) return false;
            }
            return true;
        }

        public void Display()
        {
            Console.WriteLine("Game Started!");
            Console.WriteLine("");
            Console.WriteLine("  1 2 3 4 5 6 7 8 9 10");
            for (int i = 0; i < 10; i++)
            {
                Console.Write((char)('A' + i) + " ");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
