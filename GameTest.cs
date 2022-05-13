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
        public void CanBeAStrikePlay()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);

            RollTestMethod(0, 16);

            Assert.AreEqual(24, game.Score);
        }


        [TestMethod]
        public void CanBeASparePlay()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);

            RollTestMethod(0, 17);

            Assert.AreEqual(16, game.Score);
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
        public void MayNotBeASpareThenASparePlay()
        {
            game.Roll(3);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(1);

            RollTestMethod(0, 15);

            Assert.AreEqual(20, game.Score);
        }

        [TestMethod]
        public void CanBeADoublePlay()
        {
            game.Roll(10);//first frame = 24
            game.Roll(10);//second frame = 39
            game.Roll(4);//third frame = 39 + 4
            game.Roll(1);

            RollTestMethod(0, 14);

            Assert.AreEqual(44, game.Score);
        }

        [TestMethod]
        public void CanBeADoubleAndSpare()
        {
            game.Roll(10);//first frame = 24
            game.Roll(10);//second frame = 34+14 = 48
            game.Roll(4); //third frame = 48+4 = 52
            game.Roll(10); //third frame = 65
            game.Roll(3); //forth frame = 65 + 4 = 69
            game.Roll(4); // forth frame = 69+2 = 71
            game.Roll(1); // fifth frame
            game.Roll(1); // fifth frame

            RollTestMethod(0, 13);

            Assert.AreEqual(71, game.Score);
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
