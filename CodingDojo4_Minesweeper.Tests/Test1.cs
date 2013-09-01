using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _minesweeper = new Minesweeper(new StringMatrixNavigator());
        }

        [Test]
        public void GivenAnEmptyMinesweeper_ShouldReturnsAllZeroes()
        {
            Assert.AreEqual("0000000000000000", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithOneBombInPositionZero_ShouldReturnBombOnPositionZero()
        {
            _minesweeper.Load("*...............");
            var solution = _minesweeper.Solve();
            Assert.IsTrue(solution.StartsWith("*"));
        }

        [Test]
        public void GivenAnFieldWithOneBombInPositionZero_ShouldReturnBombOnPositionZeroAndIndicate1BombOnPosition1()
        {
            _minesweeper.Load("*...............");
            var solution = _minesweeper.Solve();
            Assert.IsTrue(solution.StartsWith("*1"));
        }


        [Test]
        public void GivenAnFieldWithOneBombInPositionZero_ShouldReturnBombOnPositionZeroAndIndicate1BombOnAppropriatePositions()
        {
            _minesweeper.Load("*...............");
            var solution = _minesweeper.Solve();
            Assert.IsTrue(solution.StartsWith("*100110000000000"));
        }

        [Test]
        public void GivenAnFieldWithSomeBombs_ShouldReturnBombOnPositionZeroAndIndicate1BombOnAppropriatePositions()
        {
            /*
              
              Mine:
              *...
              .*.*
              ..*.
              *...
             
              Result:
              *221
              2*3*
              23*2
              *211
             
             */
            _minesweeper.Load("*....*.*..*.*...");
            var solution = _minesweeper.Solve();
            Assert.AreEqual(solution, "*2212*3*23*2*211");
        }


    }
}
