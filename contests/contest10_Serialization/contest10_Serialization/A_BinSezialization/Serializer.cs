using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
internal static class Serializer
{
    public static void ReadStudents(string pathToInputFile)
    {
        var inputLines = File.ReadAllLines(pathToInputFile);
        foreach (var line in inputLines)
        {
            var input = line.Split();
            List<int> grades = new List<int>();
            for (int i = 3; i < input.Length; i++)
                grades.Add(int.Parse(input[i]));
            var student = new Student(input[0], input[1], int.Parse(input[2]), grades);
            Student.students.Add(student);
        }


    }

    public static void SerializeStudents(string pathToOutputFile)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fs = new FileStream("output.bin", FileMode.Create);
        binaryFormatter.Serialize(fs, Student.students);
    }
}