
using BattleshipsGameAPI.Models;

namespace BattleshipsGameAPI.Services
{
    public interface IBoardRepository
    {
        void InitializeGrid();

        void PlaceShips();

        bool PlaceShip(Ship ship, int row, int col, bool horizontal);

        (bool,string) ProcessShot(string input);

        bool AllShipsSunk();

        void Display();


    }
}
