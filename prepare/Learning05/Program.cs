using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Samuel Dela Cruz", "Programming with Classes");
        string summary = assignment1.GetSummary();
        Console.WriteLine(summary);

        MathAssignment mathAssignment1 = new MathAssignment("Samuel Dela Cruz", "Exponents", "Section 7.3", "Problems 8-19");
        string summary1 = mathAssignment1.GetSummary();
        string homeworkList = mathAssignment1.GetHomeworkList();
        Console.WriteLine(summary1);
        Console.WriteLine(homeworkList);

        WritingAssignment writingAssignment1 = new WritingAssignment("Samuel Dela Cruz", "European History", "The Causes of World War II");
        string summary2 = writingAssignment1.GetSummary();
        string writingInformation = writingAssignment1.GetWritingInformation();
        Console.WriteLine(summary2);
        Console.WriteLine(writingInformation);
    }
}