using System;
using System.Collections.Generic;
namespace MultipleChoice
{

    interface ITestPaper
    {
        string SubjectName { get; set; }
        string TestPaperName { get; set; }
        List<IQuestion> Questions { get; set; }
    }

    interface IQuestion
    {
        string QuestionText { get; set; }

        List<IOption> Options { get; set; }

        char CorrectAnswerLetter { get; set; }

        char OptionSelectedByStudent { get; set; }

        int MarksSecured { get; set; }
    }


    interface IOption
    {
        char OptionLetter { get; set; }
        string OptionText { get; set; }

    }

    interface IStudent
    {

        int RollNo { get; set; }
        string StudentName { get; set; }
        List<ITestPaper> TestPapers { get; set; }
    }

    class TestPaper
    {

        public string SubjectName { get; set; }

        //string SubjectName;
        public string TestPaperName { get; set; }

        public List<IQuestion> Questions(List<IQuestion> questions)
        {
            return questions;
        }
    }


    class Question
    {

        public string QuestionText;

        public List<IOption> Options;

        char CorrectAnswerLetter;

        char OptionSelectedByStudent;

        //public List<IOption> Options
        //{
        //    get;
        //}

        //string QuestionText;
        //List<IOption> Options;
        //char CorrectAnswerLetter;
        //char OptionSelectedByStudent
        //int MarksSecured
    }


    class Option
    {

        public char OptionLetter;

        public string OptionText;

    }


    class Student
    {

        int RollNo;

        string StudentName;

        List<ITestPaper> TestPapers;
    }


    class Program
    {
        static void Main(string[] args)
        {

            TestPaper testPaper = new TestPaper()
            {
                SubjectName = "Capital Cities",
                TestPaperName = "America Test"
            };

            IQuestion question1 = new Question();


            // List<IQuestion> questions = testPaper.Questions({ "1A", "2C", "3D", "4A", "5A" });

            // List<Option> options[1] =  new Option { OptionLetter = 'B', OptionText = "Washington DC" } ;

            //List<Question> questions = new List<Question> {
            //       new Question {
            //           QuestionText = "What is the capital of U.S.A.", 
            //           Options = new Option { OptionLetter = 'A', OptionText = "New York" }},
            // };

            /*
        string QuestionText;

        List<IOption> Options;

        char CorrectAnswerLetter;

        char OptionSelectedByStudent;

        int MarksSecured;
             */

        }
    }
}
