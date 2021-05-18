using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public double Average { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public char Letter {
            get {
                switch (Average)
                {
                    case var av when av >= 90:
                        return 'A';

                    case var av when av >= 80:
                        return 'B';

                    case var av when av >= 70:
                        return 'C';

                    case var av when av >= 60:
                        return 'D';

                    default:
                        return 'F';
                }
            }
        }

        public Statistics()
        {
            this.Average = 0.0;
            this.High = double.MinValue;
            this.Low = double.MaxValue;
        }

        public void Generate(List<double> grades)
        {
            CalculateAverage(grades);
            Print();
        }

        private void CalculateAverage(List<double> grades)
        {
            Average = 0.0;

            foreach (var grade in grades)
            {
                Low = Math.Min(grade, Low);
                High = Math.Max(grade, High);

                Average += grade;
            }

            if (Average > 0.0)
            {
                Average /= grades.Count;
            }
        }

        private void Print()
        {
            Console.WriteLine($"The lowest grade is {Low:N1}");
            Console.WriteLine($"The highest grade is {High:N1}");
            Console.WriteLine($"The average grade is {Average:N1}");
            Console.WriteLine($"The letter grade is {Letter}");
        }
    }
}