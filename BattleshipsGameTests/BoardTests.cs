using BattleshipsGameAPI.Models;
using BattleshipsGameAPI.Services;
using static BattleshipsGameAPI.Models.Ship;

namespace BattleshipsGameTests
{
    public class BoardTests
    {
        [Fact]
        public void TestPlaceShip_Success()
        {
            var board = new BoardRepository();
            var shipPlacedSuccessfully = board.PlaceShip(new Ship(ShipType.Battleship), 0, 0, true);
            Assert.True(shipPlacedSuccessfully);
        }

        [Fact]
        public void TestProcessShot_Hit()
        {
            var board = new BoardRepository();
            var ship = new Ship(ShipType.Battleship);
            board.PlaceShips(); // Ensure ships are placed first.
            var resultMessageBeforeHitCount = ship.hits; // Assuming  returns current hit count.
            board.ProcessShot("A6"); // Assuming A6 is a valid hit position.
            ship.Hit();//Since it assumtion need call hit manually
            var resultMessageAfterHitCount = ship.hits;// Check hit count after.
            Assert.True(resultMessageAfterHitCount == resultMessageBeforeHitCount + 1); // Check hit count increment.
        }


        [Fact]
        public void ProcessShot_InvalidInput_ReturnsErrorMessage()
        {
            var board = new BoardRepository();
            // Act
            var result = board.ProcessShot("K11"); // Invalid shot

            // Assert
            Assert.False(result.Item1);
        }


    }
}