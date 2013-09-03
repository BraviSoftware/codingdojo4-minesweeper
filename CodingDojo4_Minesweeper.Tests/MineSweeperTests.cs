using NUnit.Framework;

namespace CodingDojo4_Minesweeper.Tests
{
    [TestFixture]
    public class MinesweeperTest
    {
        private Minesweeper _minesweeper;

        [SetUp]
        public void Setup()
        {
            _minesweeper = new Minesweeper();
        }

        [Test]
        public void GivenAnEmptyMinesweeperShouldReturnsAll0()
        {
            Assert.AreEqual("0000000000000000", _minesweeper.Field);
        }

        [Test]
        public void GivenAnFieldWithOneBombShouldReturnOneStar()
        {
            _minesweeper.AddBombToFieldAt(0);
            Assert.AreEqual("*000000000000000", _minesweeper.Field);
        }

        [Test]
        public void GivenAnFieldWithOneBombInPosition3ShouldReturnOneStar()
        {
            _minesweeper.AddBombToFieldAt(3);
            Assert.AreEqual("000*000000000000", _minesweeper.Field);
        }

        [Test]
        public void GivenAnFieldWithOneBombJustOnTopShouldReturnCorrectSolution()
        {
            /*
            * 01*1
            * 0111
            * 0000
            * 0000
            */
            _minesweeper.AddBombToFieldAt(2);
            Assert.AreEqual("01*1011100000000", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithOneBombJustOnTheLastRowShouldReturnCorrectSolution()
        {
            /*
            * 0000
            * 0000
            * 1110
            * 1*10
            */
            _minesweeper.AddBombToFieldAt(13);
            Assert.AreEqual("0000000011101*10", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithOneBombJustOnTheLeftShouldReturnCorrectSolution()
        {
            /*
            * 1100
            * *100
            * 1100
            * 0000
            */
            _minesweeper.AddBombToFieldAt(4);
            Assert.AreEqual("1100*10011000000", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithOneBombJustOnTheLeftShouldReturnCorrectSolution2()
        {
            /*
            * 0000
            * 1100
            * *100
            * 1100
            */
            _minesweeper.AddBombToFieldAt(8);
            Assert.AreEqual("00001100*1001100", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithOneBombOnLeftBottomCornerShouldReturnCorrectSolution()
        {
            /*
            * 0000
            * 0000
            * 1100
            * *100
            */
            _minesweeper.AddBombToFieldAt(12);
            Assert.AreEqual("000000001100*100", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithOneBombJustOnTheRightShouldReturnCorrectSolution()
        {
            /*
            * 0011
            * 001*
            * 0011
            * 0000
            */
            _minesweeper.AddBombToFieldAt(7);
            Assert.AreEqual("0011001*00110000", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithOneBombJustOnTheRightShouldReturnCorrectSolution2()
        {
            /*
            * 0000
            * 0011
            * 001*
            * 0011
            */
            _minesweeper.AddBombToFieldAt(11);
            Assert.AreEqual("00000011001*0011", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithOneBombOnRightBottomCornerShouldReturnCorrectSolution()
        {
            /*
            * 0000
            * 0000
            * 0011
            * 001*
            */
            _minesweeper.AddBombToFieldAt(15);
            Assert.AreEqual("000000000011001*", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithOneBombOnRightTopCornerShouldReturnCorrectSolution()
        {
            /*
            * 001*
            * 0011
            * 0000
            * 0000
            */
            _minesweeper.AddBombToFieldAt(3);
            Assert.AreEqual("001*001100000000", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithOneBombInPosition1ShouldReturnCorrectSolution()
        {
            _minesweeper.AddBombToFieldAt(1);
            Assert.AreEqual("1*10111000000000", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithOneBombInPosition6ShouldReturnCorrectSolution()
        {
           /*
            * 0111
            * 01*1
            * 0111
            * 0000
            */
            _minesweeper.AddBombToFieldAt(6);
            Assert.AreEqual("011101*101110000", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithBombsInAllCornersShouldReturnCorrectSolution()
        {
            /*
            * *11*
            * 1111
            * 1111
            * *11*
            */
            _minesweeper.AddBombToFieldAt(0);
            _minesweeper.AddBombToFieldAt(3);
            _minesweeper.AddBombToFieldAt(12);
            _minesweeper.AddBombToFieldAt(15);
            Assert.AreEqual("*11*11111111*11*", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithBombsInAllLeftCornerShouldReturnCorrectSolution()
        {
            /*
            * *200
            * *300
            * *300
            * *200
            */
            _minesweeper.AddBombToFieldAt(0);
            _minesweeper.AddBombToFieldAt(4);
            _minesweeper.AddBombToFieldAt(8);
            _minesweeper.AddBombToFieldAt(12);
            Assert.AreEqual("*200*300*300*200", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithBombsInAllRightCornerShouldReturnCorrectSolution()
        {
            /*
            * 002*
            * 003*
            * 003*
            * 002*
            */
            _minesweeper.AddBombToFieldAt(3);
            _minesweeper.AddBombToFieldAt(7);
            _minesweeper.AddBombToFieldAt(11);
            _minesweeper.AddBombToFieldAt(15);
            Assert.AreEqual("002*003*003*002*", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnIdentityMatrixAsBombPositionsShouldReturnCorrectSolution()
        {
            /*
            * *210
            * 2*21
            * 12*2
            * 012*
            */
            _minesweeper.AddBombToFieldAt(0);
            _minesweeper.AddBombToFieldAt(5);
            _minesweeper.AddBombToFieldAt(10);
            _minesweeper.AddBombToFieldAt(15);
            Assert.AreEqual("*2102*2112*2012*", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnEmptyField_SolutionWillBeAllZeroes()
        {
            Assert.AreEqual("0000000000000000", _minesweeper.Solve());
        }

        [Test]
        public void GivenADefaultMatrixItsLengthShouldBeSixteen()
        {
            Assert.AreEqual(16, _minesweeper.Field.Count);
        }
    }
}