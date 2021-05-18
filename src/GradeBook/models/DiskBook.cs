using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {

        private readonly string fileName;

        public DiskBook(string name) : base(name)
        {
            fileName = $"{Name}.txt";
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText(fileName))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var statistcs = new Statistics();
            var grades = new List<double>();

            using(var reader = File.OpenText(fileName))
            {
                while(!reader.EndOfStream)
                {
                    var grade = reader.ReadLine();

                    if (!string.IsNullOrEmpty(grade))
                    {
                        grades.Add(double.Parse(grade));
                    }
                }
            }
            
            statistcs.Generate(grades);

            return statistcs;
        }
    }
}