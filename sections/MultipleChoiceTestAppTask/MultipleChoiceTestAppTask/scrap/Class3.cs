using System;

using System.Linq;
using System.Collections.Generic;


namespace ConsoleApp1

{

    interface ITestPaper {

        string SubjectName { get; set; }

        string TestPaperName { get; set; }

        List<IQuestion> Questions { get; set; }
    }


    interface IQuestion {
        string QuestionText { get; set; }

        List<IOption> Options { get; set; }

        char CorrectAnswerLetter { get; set; }

        char OptionSelectedByStudent { get; set; }

        int MarksSecured { get; set; }
    }


    interface IOption {
        char OptionLetter { get; set; }

        string OptionText { get; set; }
    }


    interface IStudent {
        int RollNo { get; set; }

        string StudentName { get; set; }

        List<ITestPaper> TestPapers { get; set; }
    }






    class TestPaper {
        string SubjectName;

        string TestPaperName;

        List<IQuestion> Questions;
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
        public int RollNo;

        public string StudentName;

        List<ITestPaper> TestPapers;

    }

    internal class Program

    {

        static void Main()
        {
           
            TestPaper test1 = new TestPaper();

            TestPaper test2 = new TestPaper();

            Student student = new Student { RollNo = 1111, StudentName = "Joey", };

            Program.CreateTestPapers(test1,test2);

            Console.WriteLine("Test 1 Starting");

           // SolveTest(test1);

           // SolveTest(test2);

         //   Console.WriteLine(CalculateMarks(test1, test2));


        }

        public static string Test() {

            return "Test";

        }
        public static void CreateTestPapers(TestPaper test1, TestPaper test2)

        {
            test1 = new TestPaper();

            test2 = new TestPaper();


            for (int i = 0; i < 10; i++)

            {

                Console.WriteLine("Enter  for Test1, Q " + (i + 1));

                Console.WriteLine(" Question Text:");

                Question question = new Question();

                string questionText = Console.ReadLine();

                for (int j = 0; j < 4; j++)

                {

                    Console.WriteLine("Enter Option " + (j + 1));

                    string optionText = Console.ReadLine();

                    Console.WriteLine("Enter Option Letter");

                    char optionLetter = Console.ReadLine()[0];

                    question.Options.Add(new Option { OptionLetter = optionLetter, OptionText = optionText });

                }

                question.QuestionText = questionText;

                Console.WriteLine("Enter Correct Answer");

                char correct = Console.ReadLine()[0];

                question.CorrectAnswerLetter = correct;

                Console.WriteLine("Enter Mark for this Question");

                int mark = int.Parse(Console.ReadLine());

                question.MarksSecured = mark;



                test1.Questions.Add(question);

            }

            for (int i = 0; i < 10; i++)

            {

                Console.WriteLine("Enter for Test 2, Q " + (i + 1));

                Console.WriteLine(" Question Text:");

                Question question = new Question();

                string questionText = Console.ReadLine();

                for (int j = 0; j < 4; j++)

                {

                    Console.WriteLine("Enter Option " + (j + 1));

                    string optionText = Console.ReadLine();

                    Console.WriteLine("Enter Option Letter");

                    char optionLetter = Console.ReadLine()[0];

                    question.Options.Add(new Option { OptionLetter = optionLetter, OptionText = optionText });

                }

                question.QuestionText = questionText;

                Console.WriteLine("Enter Correct Answer");

                char correct = Console.ReadLine()[0];

                question.CorrectAnswerLetter = correct;

                Console.WriteLine("Enter Mark for this Question");

                int mark = int.Parse(Console.ReadLine());

                question.MarksSecured = mark;



                test2.Questions.Add(question);

            }



        }


        public static void SolveTest(TestPaper test)

        {



            for (int i = 0; i < test.Questions.Count; i++)

            {

                var question = test.Questions[i];

                Console.WriteLine(question.QuestionText);

                foreach (var item in question.Options)

                {

                    Console.WriteLine(item.OptionLetter + ")" + item.OptionText);

                }

                char studentAnswer = Console.ReadLine()[0];

                question.OptionSelectedByStudent = studentAnswer;



            }





        }

        public static int CalculateMarks(params TestPaper[] tests)

        {

            int studentMark = 0;

            foreach (var test in tests)

            {

                foreach (var item in test.Questions)

                {

                    if (item.CorrectAnswerLetter == item.OptionSelectedByStudent)

                    {

                        studentMark += item.MarksSecured;

                    }

                }

            }



            return studentMark;

        }

    }

}

