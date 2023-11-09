

using System.Linq;

class Question
{
    public string questionText;
    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;
    public bool hasOnlyValidAnswers;
    public char correctAnswerLetter;
    private static char defaultCorrectAnswerLetter = 'X';

    //Constructor 1
    public Question()
    {
        //TO DO: Initialize questionText, optionA, optionB, optionC, optionD as null. Initialize correctAnswerLetter to the value of static field 'defaultCorrectAnswerLetter'.
        this.questionText = "What is the capital of the USA?";
        this.optionA = "London";
        this.optionB = "New York";
        this.optionC = "Washington,D.C";
        this.optionD = "San Diego";
        this.correctAnswerLetter = 'C';
        defaultCorrectAnswerLetter = 'C'; //static
    }

    //Constructor 2
    public Question(string questionText)
    {
        //TO DO: Initialize questionText. Also, initialize optionA, optionB, optionC, optionD as null. Initialize correctAnswerLetter to the value of static field 'defaultCorrectAnswerLetter'.
        this.questionText = questionText;
        this.optionA = "London";
        this.optionB = "New York";
        this.optionC = "Washington,D.C";
        this.optionD = "San Diego";
        this.correctAnswerLetter = 'C';
        defaultCorrectAnswerLetter = 'C'; //static
    }

    //Constructor 3
    public Question(string questionText, string optionA, string optionB, string optionC, string optionD, char correctAnswerLetter)
    {
        //TO DO: Initialize questionText, optionA, optionB, optionC, optionD and correctAnswerText. Validate the value of correctAnswerLetter. It should either 'A', 'B', 'C' or 'D' only
        this.questionText = questionText;
        this.optionA = optionA;
        this.optionB = optionB;
        this.optionC = optionC;
        this.optionD = optionD;  

        if (new[] { 'A', 'B','C','D' }.Contains(correctAnswerLetter)) {

                
         this.hasOnlyValidAnswers = true;


        } else {

         this.hasOnlyValidAnswers = false;

        }

    }
    public bool AreOptionsValid()
    {
        //TO DO: Return true, if at least two options are not null
        int nullCount = 0;

        if (this.optionA == null) { nullCount++; }
        if (this.optionB == null) { nullCount++; }
        if (this.optionC == null) { nullCount++; }
        if (this.optionD == null) { nullCount++; }

        System.Console.WriteLine("Null Count" + nullCount);

        if (nullCount < 2)
        {

            return true;

        } else
        {
            return false;

        }

    }
}

class Program
{
    static void Main()
    {
        //TO DO: Create an object of Question class and pass no arguments to the constructor
        Question questionNoArgs = new Question();
        System.Console.WriteLine("Options are valid ? "+questionNoArgs.AreOptionsValid());

        //TO DO: Create an object of Question class and pass value for questionText only to the constructor.

        Question questionSingleArg = new Question("What is the capital of the USA?");
        System.Console.WriteLine("Options are valid ? " + questionSingleArg.AreOptionsValid());

        //TO DO: Create an object of Question class and pass values for questionText, optionA, optionB, optionC, optionD and correctAnswerLetter to the constructor.
        Question questionMultipleArgs = new Question("What is the capital of the USA?", "London", "New York", "Washington,D.C", "San Diego",'C');
        System.Console.WriteLine("Options are valid ? " + questionMultipleArgs.AreOptionsValid());
        System.Console.WriteLine("Answers are valid ? " + questionMultipleArgs.hasOnlyValidAnswers);


        //TO DO: Create an object of Question class and pass values for questionText, optionA, optionB, optionC, optionD only to the constructor.
        Question questionObjectInitialized = new Question(){optionA = "London", optionB = "New York", optionC = "Washington,D.C", optionD = "San Diego" };
        System.Console.WriteLine("Options are valid ? " + questionObjectInitialized.AreOptionsValid());

    }
}