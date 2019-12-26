using System;
using System.Collections.Generic;
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
            {
                throw new InvalidOperationException("Ranked grading requires a minimum of 5 students to work");
            }

            var LetterGradeGroupSize = (int)Math.Ceiling(Students.Count / 5.0);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= grades[LetterGradeGroupSize - 1])
                return 'A';
            else if (averageGrade >= grades[(LetterGradeGroupSize * 2) - 1])
                return 'B';
            else if (averageGrade >= grades[(LetterGradeGroupSize * 3) - 1])
                return 'C';
            else if (averageGrade >= grades[(LetterGradeGroupSize * 4) - 1])
                return 'D';
            else
                return 'F';
        }
    }
}