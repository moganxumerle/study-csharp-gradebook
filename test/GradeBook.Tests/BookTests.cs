using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            var book = new InMemoryBook("");
            book.AddGrade(12.4);
            book.AddGrade(43.5);
            book.AddGrade(89.4);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(12.4, result.Low);
            Assert.Equal(89.4, result.High);
            Assert.Equal(48.43, result.Average, 1);
            Assert.Equal('F', result.Letter);
        }

        [Fact]
        public void BookCalculatesAnAverageGradeWithLetterA()
        {
            //arrange
            var book = new InMemoryBook("");
            book.AddGrade(90.4);
            book.AddGrade(88.5);
            book.AddGrade(95.4);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(88.5, result.Low);
            Assert.Equal(95.4, result.High);
            Assert.Equal(91.4, result.Average, 1);
            Assert.Equal('A', result.Letter);
        }

        [Fact]
        public void BookCantAddInvalidGrade()
        {
            //arrange
            var book = new InMemoryBook("");
            book.AddGrade(-10.0);
            book.AddGrade(150.3);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(double.MaxValue, result.Low);
            Assert.Equal(double.MinValue, result.High);
            Assert.Equal(0.0, result.Average);
        }
    }
}
