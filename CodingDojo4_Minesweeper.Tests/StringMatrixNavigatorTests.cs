using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodingDojo4_Minesweeper.Tests
{
    [TestFixture]
    public class StringMatrixNavigatorTests
    {
        private StringMatrixNavigator _nav;
        private const string Field16 = "................";

        [SetUp]
        public void Setup()
        {
            _nav = new StringMatrixNavigator();
            _nav.Load(Field16);
        }

        [Test]
        public void GivenAString_WillDetectDimension()
        {
            var input = "****";
            _nav.Load(input);
            Assert.That(_nav.Dimension(), Is.EqualTo(2));
        }

        [Test]
        public void GivenAStringWith1Point_WillDetectDimension()
        {
            var input = "*";
            _nav.Load(input);
            Assert.That(_nav.Dimension(), Is.EqualTo(1));
        }

        [Test]
        public void CanCheckThatAPositionIsInTheFirstRow([Range(0,3)] int position)
        {
            Assert.IsTrue(_nav.IsPositionInFirstRow(position));
        }

        [Test]
        public void CanCheckThatAPositionIsNotInTheFirstRow([Range(4,15)] int position)
        {
            Assert.IsFalse(_nav.IsPositionInFirstRow(position));
        }

        [Test]
        public void CanCheckThatAPositionIsInTheLastRow([Range(12, 15)] int position)
        {
            Assert.IsTrue(_nav.IsPositionInLastRow(position));
        }

        [Test]
        public void CanCheckThatAPositionIsOnTheLeftBorder([Values(0,4,8,12)] int position)
        {
            Assert.IsTrue(_nav.IsPositionInLeftBorder(position));
        }

        [Test]
        public void CanCheckThatAPositionIsNotOnTheLeftBorder([Values(1,5,9,13)] int position)
        {
            Assert.IsFalse(_nav.IsPositionInLeftBorder(position));
        }

        [Test]
        public void CanCheckThatAPositionIsOnTheRightBorder([Values(3, 7, 11, 15)] int position)
        {
            Assert.IsTrue(_nav.IsPositionInRightBorder(position));
        }

        [Test]
        public void CanGetPositionOnTopOfAnother()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnTopOf(2), Is.EqualTo('A'));
            Assert.That(_nav.GetValueOnTopOf(3), Is.EqualTo('B'));
        }

        [Test]
        public void CanGetPositionBelowAnother()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnBelow(0), Is.EqualTo('C'));
            Assert.That(_nav.GetValueOnBelow(1), Is.EqualTo('D'));
        }

        [Test]
        public void CanGetPositionOnLeftOfAnother()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnLeft(1), Is.EqualTo('A'));
        }

        [Test]
        public void GetValueOnLeftReturnsNullWhenItsOnTheLeftBorder()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnLeft(0), Is.Null);
        }
        
        [Test]
        public void CanGetPositionOnRightOfAnother()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnRight(0), Is.EqualTo('B'));
        }

        [Test]
        public void GetValueOnRightReturnsNullWhenItsOnTheRightBorder()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnRight(1), Is.Null);
        }


        [Test]
        public void CanGetPositionOnTopRightOfAnother()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnTopRight(2), Is.EqualTo('B'));
        }

        [Test]
        public void CanGetPositionOnTopRightOfAnother_ReturnsNullIfPositionIsInFirstRow()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnTopRight(0), Is.Null);
        }

        [Test]
        public void CanGetPositionOnTopRightOfAnother_ReturnsNullIfPositionIsInRightBorder()
        {
            const string input = "ABCDEFGHIJKLMNOP";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnTopRight(7), Is.Null);
        }

        [Test]
        public void CanGetPositionOnTopLeftOfAnother()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnTopLeft(3), Is.EqualTo('A'));
        }

        [Test]
        public void CanGetPositionOnTopLeftOfAnother_ReturnsNullIfPositionIsInFirstRow()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnTopLeft(0), Is.Null);
        }

        [Test]
        public void CanGetPositionOnTopLeftOfAnother_ReturnsNullIfPositionIsInLeftBorder()
        {
            const string input = "ABCDEFGHIJKLMNOP";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnTopLeft(4), Is.Null);
        }

        [Test]
        public void CanGetPositionOnBelowLeftOfAnother()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnBelowLeft(1), Is.EqualTo('C'));
        }

        [Test]
        public void CanGetPositionOnBelowLeftOfAnother_ReturnsNullIfPositionIsInLastRow()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnBelowLeft(3), Is.Null);
        }

        [Test]
        public void CanGetPositionOnBelowLeftOfAnother_ReturnsNullIfPositionIsInLeftBorder()
        {
            const string input = "ABCDEFGHIJKLMNOP";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnBelowLeft(4), Is.Null);
        }

        [Test]
        public void CanGetPositionOnBelowRightOfAnother()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnBelowRight(0), Is.EqualTo('D'));
        }

        [Test]
        public void CanGetPositionOnBelowRightOfAnother_ReturnsNullIfPositionIsInLastRow()
        {
            const string input = "ABCD";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnBelowRight(3), Is.Null);
        }

        [Test]
        public void CanGetPositionOnBelowRightOfAnother_ReturnsNullIfPositionIsInRightBorder()
        {
            const string input = "ABCDEFGHIJKLMNOP";
            _nav.Load(input);
            Assert.That(_nav.GetValueOnBelowRight(7), Is.Null);
        }

    }
}
