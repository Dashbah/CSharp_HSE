using System;
using System.Collections.Generic;

internal static class Analytics
{
    public static void WriteStudentsWithGpaNoLessThanAverage(List<Student> students, string pathToOutputFile,
        double gpa)
    {
        Console.WriteLine("{0:0.00}", gpa);
        var numOfGrades = students[0].Grades.ToArray().Length;
        
        foreach (var student in students)
        {
            double s = 0;
            foreach (var grade in student.Grades)
                s += grade;
            s /= numOfGrades;
            if (s >= gpa)
                Console.WriteLine(student);
        }
    }

    public static double FindGpa(List<Student> students)
    {
        int numOfGrades = students[0].Grades.ToArray().Length;
        double summ = 0;
        foreach (var student in students)
            foreach (var grade in student.Grades)
                summ += grade;
        return summ / (students.ToArray().Length * numOfGrades);
    }
}