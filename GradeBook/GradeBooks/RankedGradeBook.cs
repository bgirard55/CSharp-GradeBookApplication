using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            var cutoff = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();

            if (grades[cutoff - 1] <= averageGrade)
                return 'A';
            else if (grades[cutoff*2-1] <= averageGrade)
                return 'B';
            else if (grades[cutoff*3-1] <= averageGrade)
                return 'C';
            else if (grades[cutoff*4-1] <= averageGrade)
                return 'D';

            return 'F';
        }
    }
}
