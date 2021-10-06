using System;
using Xunit;
using Calculator_project;
namespace Assignment3_XUNIT_calc_Martin
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(10, 10, 20, true)]
        [InlineData(10, 20, 20, false)]
        [InlineData(100, 10, 0,false)]
        [InlineData(55, 10, 90, false)]
        public void Plustest(double firstNumber,double secondNumber, double wantedSumOfNumbers, bool wantedFuncSumIsCorrect)
        {
            Program.Plus(firstNumber, secondNumber);
            double results = Program.result;
            bool sumIsCorrect = results == wantedSumOfNumbers;
            Assert.True(wantedFuncSumIsCorrect == sumIsCorrect);
        }

        [Theory]
        [InlineData(20, 10, 10, true)]
        [InlineData(10, 20, 20, false)]
        [InlineData(100, 10, 0, false)]
        [InlineData(55, 10, 90, false)]
        public void Minustest(double firstNumber, double secondNumber, double wantedDifferenceOfNumbers, bool wantedFuncDifIsCorrect)
        {
            Program.Minus(firstNumber, secondNumber);
            double results = Program.result;
            bool calculationIsCorrect = results == wantedDifferenceOfNumbers;
            Assert.True(wantedFuncDifIsCorrect == calculationIsCorrect);
        }

        [Theory]
        [InlineData(2, 1, 2, true)]
        [InlineData(10, 90, 20, false)]
        [InlineData(100, 0, 0, true)]
        [InlineData(55.3, 31.2, 1725.36, true)] 
        public void Multiplytest(double firstNumber, double secondNumber, double wantedProductOfNumbers, bool wantedFuncProductIsCorrect)
        {
            Program.Multi(firstNumber, secondNumber);
            double results = Program.result;
            bool calculationIsCorrect = results == wantedProductOfNumbers;
            Assert.True(wantedFuncProductIsCorrect == calculationIsCorrect);
        }


        [Theory]
        [InlineData(2, 10, 0.2, true)]
        [InlineData(10, 20, 20, false)]
        [InlineData(100, 90, 0, false)]
        [InlineData(10, 3, 3.3, false)] //program should be exact
        public void DivideTest(double firstNumber, double secondNumber, double wantedDivisionOfNumbers, bool wantedFuncDivisionIsCorrect)
        {
            Program.Divide(firstNumber, secondNumber);
            double results = Program.result;
            bool calculationIsCorrect = results == wantedDivisionOfNumbers;
            Assert.True(wantedFuncDivisionIsCorrect == calculationIsCorrect);
        }//this test is NOT designed to test divided by zero as it is done in the next test
        [Fact]       
        public void DivideByZeroTest()
        {
            double savedResult = Program.result; 
            Program.Divide(10, 0);
            Assert.Equal(savedResult, Program.result); //check if the value remain the same after the calculation
            Assert.True(Program.dividedbyzero); //check if the bool divided by zero is true
            
        }

        [Theory]
        [InlineData(new double[] { 10, 150 }, 150, false)]
        [InlineData(new double[] {10,40,80,20},150,true)] 
        [InlineData(new double[] { }, 160, false)]
        [InlineData(new double[] { }, 0, true)]
        public void AddWithArray(double [] firstArray ,double wantedSum, bool wantedSumIsCorrect)
        {
            Program.Plus(firstArray);
            double results = Program.result;
            bool calculationIsCorrect = results == wantedSum;
            Assert.Equal(wantedSumIsCorrect, calculationIsCorrect);
        }

        [Theory]
        [InlineData(new double[] { 10, 40, 80, 20 }, -150, true)]        
        [InlineData(new double[] { -10, -40, -80, -20 }, 150, true)]
        [InlineData(new double[] { }, 150, false)]
        [InlineData(new double[] { }, 0, true)]
        public void SubWithArray(double[] firstArray, double wantedDifference, bool wantedDifferenceIsCorrect)
        {
            Program.Minus(firstArray);
            double results = Program.result;
            bool calculationIsCorrect = results == wantedDifference;
            Assert.Equal(wantedDifferenceIsCorrect, calculationIsCorrect);
        }
    }
}
