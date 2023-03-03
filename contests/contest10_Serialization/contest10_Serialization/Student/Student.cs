﻿using System;
using System.Collections.Generic;

[Serializable]
internal class Student
{
    public static List<Student> students = new List<Student>();
    string name;
    string lastName;
    int groupNumber;
    List<int> grades;
    
    public List<int> Grades {
        get => grades;
        set { this.grades = value; }
    }
    public Student(string name, string lastName, int groupNumber, List<int> grades)
    {
        this.name = name;
        this.lastName = lastName;
        this.groupNumber = groupNumber;
        this.grades = grades;
    }
    public override string ToString()
    {
        return $"{this.name} {this.lastName} {this.groupNumber}";
    }
}