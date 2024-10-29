using BattleshipsGameAPI.Models;
using static BattleshipsGameAPI.Models.Ship;

namespace BattleshipsGameAPI.Services
{
    public class GameRepository : IGameRepository
    {
        private readonly IBoardRepository _boardRepository;
       // public char[,] grid;
       // public Ship[] ships;

        public GameRepository(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository ?? throw new ArgumentNullException(nameof(boardRepository));
            _boardRepository.PlaceShips();
        }
      
        public void Start()
        {
            while (true)
            {
                Console.Clear();
                _boardRepository.Display();
                Console.Write("Enter your shot (Eg.'A5'=> Input Case-sensitive 'a5' => Invalid input): ");
                string input = Console.ReadLine().ToUpper();

              // var output = _boardRepository.ProcessShot(input);

               //Console.Write("Status: " + output.Item2);


                if (_boardRepository.ProcessShot(input).Item1)
                {
                    if (_boardRepository.AllShipsSunk())
                    {
                        Console.WriteLine("Congratulations! You've sunk all the ships!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }

        //public void PlaceShips()
        //{
        //    ships[0] = new Ship(ShipType.Battleship);
        //    ships[1] = new Ship(ShipType.Destroyer);
        //    ships[2] = new Ship(ShipType.Destroyer);

        //    Random rand = new Random();
        //    foreach (var ship in ships)
        //    {
        //        bool placed = false;
        //        while (!placed)
        //        {
        //            int row = rand.Next(0, 10);
        //            int col = rand.Next(0, 10);
        //            bool horizontal = rand.Next(0, 2) == 0;

        //            placed = PlaceShip(ship, row, col, horizontal);
        //        }
        //    }
        //}

        //public bool PlaceShip(Ship ship, int row, int col, bool horizontal)
        //{
        //    if (horizontal)
        //    {
        //        if (col + ship.Size > 10) return false;

        //        for (int i = 0; i < ship.Size; i++)
        //        {
        //            if (grid[row, col + i] != '~') return false;
        //        }

        //        for (int i = 0; i < ship.Size; i++)
        //        {
        //            grid[row, col + i] = ship.Symbol;
        //        }
        //    }
        //    else
        //    {
        //        if (row + ship.Size > 10) return false;

        //        for (int i = 0; i < ship.Size; i++)
        //        {
        //            if (grid[row + i, col] != '~') return false;
        //        }

        //        for (int i = 0; i < ship.Size; i++)
        //        {
        //            grid[row + i, col] = ship.Symbol;
        //        }
        //    }

        //    return true;
        //}
    }
}
