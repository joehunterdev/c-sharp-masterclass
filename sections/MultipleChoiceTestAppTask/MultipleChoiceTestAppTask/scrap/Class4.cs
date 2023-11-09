using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Sharp_Compiler
{

    public class MainClass
    {
        public static void Main(string[] args)
        {
            Testpaper paper1 = new Testpaper("Math", new List<string>() { "1A", "2C", "3D", "4A", "5A" }, "60%");
            Testpaper paper2 = new Testpaper("Chemistry", new List<string>() { "1C", "2C", "3D", "4A" }, "75%");
            Testpaper paper3 = new Testpaper("Computing", new List<string>() { "1D", "2C", "3C", "4B", "5D", "6C", "7A" }, "75%");

            Student student1 = new Student();
            Student student2 = new Student();


            Console.WriteLine(student1.TestsTaken);
            student1.TakeTest(paper1, new List<string>() { "1A", "2D", "3D", "4A", "5A" });
            Console.WriteLine(student1.TestsTaken);

            student2.TakeTest(paper2, new List<string>() { "1C", "2D", "3A", "4C" });
            student2.TakeTest(paper3, new List<string>() { "1A", "2C", "3A", "4C", "5D", "6C", "7B" });
            Console.WriteLine(student2.TestsTaken);
        }

    }

    public interface ITestPaper
    {
        string Subject
        {
            get;
        }

        List<string> MarkScheme
        {
            get;
        }

        int PassMark
        {
            get;
        }
    }

    public class Testpaper
    {
        public string Subject
        {
            get;
        }

        public List<string> MarkScheme
        {
            get;
        }

        public int PassMark
        {
            get;
        }

        public Testpaper(string subject, List<string> markScheme, string passMark)
        {
            Subject = subject;
            MarkScheme = markScheme;
            PassMark = Int32.Parse(passMark.Trim('%'));
        }
    }

    interface IStudent
    {
        string[] TestsTaken
        {
            get;
        }

        void TakeTest(Testpaper paper, List<string> answers);
    }

    public class Student
    {
        int correctans, incorrectans;
        double gradepercent;
        private List<string> answers;

        public List<string> TestsTaken
        {
            get
            {
                if (TestsTaken.Count == 0)
                    Console.WriteLine("No tests taken");
                return null;
            }
        }

        public void TakeTest(Testpaper paper, List<string> _answers)
        {
            for (int i = 0; i < paper.MarkScheme.Count; i++)
            {
                if (_answers[i] == paper.MarkScheme[i])
                    correctans++;
                else
                    incorrectans++;
            }
            gradepercent = Math.Round((double)correctans / paper.MarkScheme.Count, 0);
            if (gradepercent >= paper.PassMark)
            {
                TestsTaken.Add($"{paper.Subject}: Passed! {gradepercent}%");

            }
            else if (gradepercent < paper.PassMark)
            {
                TestsTaken.Add($"{paper.Subject}: Failed! {gradepercent}%");
            }
        }
    }
}