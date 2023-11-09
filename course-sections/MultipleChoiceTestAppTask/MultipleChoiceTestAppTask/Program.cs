using System;
using System.Collections.Generic;
namespace MultipleChoiceTestAppTask
{

    //interface ITestPaper {
    //    string SubjectName { get; set; }
    //   string TestPaperName { get; set; }
    //   List<IQuestion> Questions { get; set; }
    //}

    //interface IQuestion {
    //    string QuestionText { get; set; }

    //    List<IOption> Options { get; set; }

    //    char CorrectAnswerLetter { get; set; }

    //    char OptionSelectedByStudent { get; set; }

    //    int MarksSecured { get; set; }
    //}


    //interface IOption {
    //    char OptionLetter { get; set; }
    //    string OptionText { get; set; }

    //}

    //interface IStudent {

    //    int RollNo { get; set; }
    //    string StudentName { get; set; }
    //    List<ITestPaper> TestPapers { get; set; }
    //}

    class TestPaper {

        public string SubjectName { get; set; }

        //string SubjectName;
        public string TestPaperName { get; set; }
        //string TestPaperName;

       // List<IQuestion> Questions;

        //public List<IQuestion> Questions(List<IQuestion> questions)
        //{
        //    // do something
        //}
    }


    class Question {

        string QuestionText;

        List<IOption> Options;

        char CorrectAnswerLetter;

        char OptionSelectedByStudent;

        int MarksSecured;
    }


    class Option {

        char OptionLetter;

        string OptionText;

    }


    class Student {

        int RollNo;

        string StudentName;

        List<ITestPaper> TestPapers;
    } 


    class Program
    {
        static void Main(string[] args)
        {

            TestPaper testPaper = new TestPaper() {SubjectName="Capital Cities",TestPaperName="America Test" };
 

        }
    }
}
