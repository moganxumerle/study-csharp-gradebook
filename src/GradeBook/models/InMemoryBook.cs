using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book, IBook
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                case 'F':
                    AddGrade(50);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);

                if (GradeAdded != null) 
                {
                    GradeAdded(this, new EventArgs());
                }

            }
            else
            {
                Console.WriteLine("Invalid Value");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var statistcs = new Statistics();

            statistcs.Generate(grades);
            
            return statistcs;
        }

        private List<double> grades;
    }
}