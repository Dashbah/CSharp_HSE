using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

internal static class Deserializer
{
    public static List<Student> DeserializeStudents(string pathToFile)
    {
        List<Student> students = null;
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fs = new FileStream(pathToFile, FileMode.Open);
        students = (List<Student>)binaryFormatter.Deserialize(fs);
        return students;
    }
}