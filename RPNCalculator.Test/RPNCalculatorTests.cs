using System;
using NUnit.Framework;

namespace RPNCalculator.Tests
{
    [TestFixture]
    public class RpnCalculatorTests
    {
        [Test]
        public void Should_Return_10_When_Input_Is_10()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();
            const int expected = 10;

            //Act
            var actual = rpnCalculator.Compute("10");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Return_1_When_Input_Is_1()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();
            const int expected = 1;

            //Act
            var actual = rpnCalculator.Compute("1");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Add_When_Input_Is_1_Plus_2()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();
            const int expected = 3;

            //Act
            var actual = rpnCalculator.Compute("1 2 +");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Add_When_Input_Is_1_Plus_0()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();
            const int expected = 1;

            //Act
            var actual = rpnCalculator.Compute("1 0 +");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Substract_When_Input_Is_2_Minus_1()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();
            const int expected = 1;

            //Act
            var actual = rpnCalculator.Compute("2 1 -");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Substract_When_Input_Is_6_Minus_1()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();
            const int expected = 5;

            //Act
            var actual = rpnCalculator.Compute("6 1 -");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Multiply_When_Input_Is_2_Multiply_4()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();
            const int expected = 8;

            //Act
            var actual = rpnCalculator.Compute("2 4 *");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Multiply_When_Input_Is_3_Multiply_0()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();
            const int expected = 0;

            //Act
            var actual = rpnCalculator.Compute("3 0 *");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Divide_When_Input_Is_4_Divided_By_2()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();
            const int expected = 2;

            //Act
            var actual = rpnCalculator.Compute("4 2 /");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Divide_When_Input_Is_9_Divided_By_3()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();
            const int expected = 3;

            //Act
            var actual = rpnCalculator.Compute("9 3 /");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Not_Compute_When_Input_Is_1_Divided_By_0()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => rpnCalculator.Compute("1 0 /"));
        }
        [Test]
        public void Should_Add_And_Multiply_When_Input_Is_4_Plus_1_Multiply_2()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();
            const int expected = 10;

            //Act
            var actual = rpnCalculator.Compute("2 4 1 + *");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Substract_And_Divide_When_5_Minus_1_Divided_By_4()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();
            const int expected = 1;

            //Act
            var actual = rpnCalculator.Compute("5 1 - 4 /");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Combine_Nested_Computations()
        {
            //Arrange
            var rpnCalculator = new RpnCalculator();
            const int expected = 14;

            //Act
            var actual = rpnCalculator.Compute("5 1 2 + 4 * + 3 -");

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
