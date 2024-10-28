namespace BattleshipsGameAPI.Models
{
    public class Ship
    {
        public enum ShipType
        {
            Battleship,
            Destroyer
        }

        public ShipType Type { get; private set; }
        public char Symbol { get; private set; }
        public int Size { get; private set; }
        private int hits;

        public Ship(ShipType type)
        {
            Type = type;
            hits = 0;

            switch (type)
            {
                case ShipType.Battleship:
                    Symbol = 'B';
                    Size = 5;
                    break;

                case ShipType.Destroyer:
                    Symbol = 'D';
                    Size = 4;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool Hit()
        {
            hits++;
            return IsSunk();
        }

        public bool IsSunk()
        {
            return hits >= Size;
        }
    }
}
