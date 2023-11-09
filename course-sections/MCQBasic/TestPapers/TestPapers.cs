using System;
using System.Collections.Generic;

namespace TestPapers
{
    public class Student
    {
        public int RollNo;
        public string StudentName;
        List<ITestPaper> TestPapers;
    }

    public class TestPaper
    {
        public string SubjectName;
        public string TestPaperName;
        public string[] Questions { get; set; }

        //public static implicit operator TestPaper(TestPaper v)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class Question {

       public string QuestionText;
        //List<IOption> Options; 2.0
        public string[] Options { get; set; }

        public char CorrectAnswerLetter;

        public char OptionSelectedByStudent;

        static int MarksSecured;

         public Option Add(List<Option> option) { 
            return option;
        }
    }

    public class Option {
       char OptionLetter;
       string OptionText;

    }


    class ITestPaper {
        string SubjectName { get; set; }

        string TestPaperName { get; set; }

        List<IQuestion> Questions { get; set; }
    }


    interface IQuestion {
        string QuestionText { get; set; }

       // List<IOption> Options { get; set; }

        char CorrectAnswerLetter { get; set; }

        char OptionSelectedByStudent { get; set; }

        int MarksSecured { get; set; }
    }







}
