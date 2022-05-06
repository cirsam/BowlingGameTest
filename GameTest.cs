using BowlingGameLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTest
{
    [TestClass]
    public class GameTest
    {
        private BowlingGame game;
        [TestInitialize]
        public void InitializeBowlingGameTest()
        {
            game = new BowlingGame();

        }

        [TestMethod]
        public void CanBeGutterGame()
        {
            RollTestMethod(0,20);

            Assert.AreEqual(0,game.Score);
        }

        [TestMethod]
        public void CanBeAllOnesGame()
        {
            RollTestMethod(1, 20);

            Assert.AreEqual(20, game.Score);
        }

        [TestMethod]
        public void MayNotBeASparePlay()
        {
            game.Roll(3);
            game.Roll(5);
            game.Roll(5);

            RollTestMethod(0,17);

            Assert.AreEqual(13, game.Score);
        }

        [TestMethod]
        public void CanBeASparePlay()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);

            RollTestMethod(0,17);

            Assert.AreEqual(16, game.Score);
        }

        [TestMethod]
        public void CanBeAStrikePlay()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);

            RollTestMethod(0, 16);

            Assert.AreEqual(24,game.Score);
        }

        private void RollTestMethod(int pins, int numberofRolls)
        {
            for (int i = 0; i < numberofRolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
