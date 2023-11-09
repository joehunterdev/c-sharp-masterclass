using System;
using TestPapers;
using System.Collections.Generic;
using System.Collections;

namespace MCQBasic
{
    /*
      Create a C# app that helps teachers to create tests with MCQ (Multiple Choice Questions) and then students can answer those questions and also the system find outs marks secured of the student.
      //TODO: 2.0 this demo ignore List<T> and implementation of interfaces
     */
    class Program
    {
 
        static void Main(string[] args)
        {

            //Question q1 = new Question()
            // {
            //     QuestionText = "What is the capital of USA ?",
            //     CorrectAnswerLetter = 'D',
            //     OptionSelectedByStudent = 'C',
            //     Options = new string[] { "Delaware", "New York", "Wisconsin", "Washington" },
            // };

            // Question q2 = new Question()
            // {
            //     QuestionText = "What is the capital of Spain ?",
            //     CorrectAnswerLetter = 'B',
            //     OptionSelectedByStudent = 'C',
            //     Options = new string[] { "Barcelona", "Madrid", "Badajoz", "Malaga" },

            // };

            //string[][] q = new string[4][];

            //q[1]["QuestionText"] = "What is the capital of Spain ?";
            //q1["CorrectAnswerLetter"] = "A";
            //q1["OptionSelectedByStudent"] = "C";
            //q1["OptionSelectedByStudent"] =  ;

           // string Options = new string[] { "Barcelona", "Madrid", "Badajoz", "Malaga" }

 

            string[][] q1 = {
             new string[2] {"QuestionText", "What is the capital of Spain ?" },
             new string[2] {"CorrectAnswerLetter","B" },
             new string[2] {"OptionSelectedByStudent","A" },
             new string[5] {"Options","Barcelona", "Madrid", "Badajoz", "Malaga" },
           };

            string[][] q2 = {
             new string[2] {"QuestionText", "What is the capital of USA ?" },
             new string[2] {"CorrectAnswerLetter","B" },
             new string[2] {"OptionSelectedByStudent","A" },
             new string[5] {"Options", "Delaware", "New York", "Wisconsin", "Washington" },
           };



            foreach (var item in q1)
            {

                Console.WriteLine(item[0]);

            }

            //  string[] array1 = q2.ToArray();


            //  List<Question> QuestionList = new List<Question>(){q1,q2};
            //   IEnumerable myList = QuestionList as IEnumerable;

              TestPaper test1 = new TestPaper() { SubjectName = "Capitals cities", TestPaperName = "Test 1", Questions = str[] = };




            //foreach (TestPaper item in test1) {

            //    Console.WriteLine(item.Questions);

            //}

        }
    }
}
/*
TestPaper test1 = new TestPaper();

TestPaper test2 = new TestPaper() ;

Student student = new Student { RollNo = 1111, StudentName = "Vahap", };



CreateTestPapers( test1,test2);

Console.WriteLine("Test 1 Starting");

SolveTest(test1);

SolveTest(test2);

Console.WriteLine(CalculateMarks(test1,test2));

}
 */