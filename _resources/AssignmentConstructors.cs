/*
There is a quiz application, where it contains loads of MCQs (Multiple Choice Questions).
Each question would have two, three or four options - like option A, B, C, D.


Eg:
Question: What is the capital of the USA?
Option A: London
Option B: New York
Option C: Washington, D.C.
Option D: San Diego
Correct Answer Letter: 'C'



The 'Question' class contains the following members:
- A public field to store questionText (string)
- A public field to store optionA (string)
- A public field to store optionB (string)
- A public field to store optionC (string)
- A public field to store optionD (string)
- A public field to store correctAnswerLetter (char). It should be either 'A' , 'B', 'C' or 'D'. Its value can't be any other than these.
- A private static field to store defaultCorrectAnswerLetter. Eg: 'X'. Its value can be any other letter. If no value is initialized into correctAnswerLetter field, then assign it to the value of defaultCorrectAnswerLetter i.e correctAnswerLetter=defaultCorrectAnswerLetter.
- A public constructor that receives no parameters. It initializes questionText, optionA, optionB, optionC, optionD as null. Initialize correctAnswerLetter to the value of static field 'defaultCorrectAnswerLetter'.
- A public constructor that receives questionText as parameter and initializes questionText. Also, initialize optionA, optionB, optionC, optionD as null. Initialize correctAnswerLetter to the value of static field 'defaultCorrectAnswerLetter'.
- A public constructor that initializes questionText, optionA, optionB, optionC, optionD and correctAnswerText; receive all values as parameters.
- A public method that returns true, if at least the question has two options; that means, at least two options are not null. For example, the options A, B, C are filled with some text; but the option D is null. So there are three options in the question. Our requirement is, at least there should be two options. So this question is 'valid'. So the method should return true in this case.



Create objects for 'Question' class as follows, in Main method:
- Create the first object of Question class and pass no arguments to the constructor.
- Create the second object of Question class and pass value for questionText only to the constructor.
- Create the third object of Question class and pass values for questionText, optionA, optionB, optionC, optionD and correctAnswerLetter to the constructor.
- Create the fourth object for Question class and pass values for questionText, optionA, optionB, optionC, optionD only to the constructor.

Note: Use object initializer, anywhere, when you feel a need.
*/

class Question
{
    public string questionText;
    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;
    public char correctAnswerLetter;
    private static char defaultCorrectAnswerLetter = 'X';

    //A constructor that initializes questionText, optionA, optionB, optionC, optionD as null. Initialize correctAnswerLetter to the value of static field 'defaultCorrectAnswerLetter'.
    public Question()
    {
        questionText = null;
        optionA = null;
        optionB = null;
        optionC = null;
        optionD = null;
        correctAnswerLetter = Question.defaultCorrectAnswerLetter; //defaultCorrectAnswerLetter is a static field
    }

    //A constructor that receives questionText as parameter and initializes questionText. Also, initialize optionA, optionB, optionC, optionD as null. Initialize correctAnswerLetter to the value of static field 'defaultCorrectAnswerLetter'.
    public Question(string questionText)
    {
        this.questionText = questionText;
        optionA = null;
        optionB = null;
        optionC = null;
        optionD = null;
        correctAnswerLetter = Question.defaultCorrectAnswerLetter; //defaultCorrectAnswerLetter is a static field
    }

    //A constructor that initializes questionText, optionA, optionB, optionC, optionD and correctAnswerText
    public Question(string questionText, string optionA, string optionB, string optionC, string optionD, char correctAnswerLetter)
    {
        this.questionText = questionText;
        this.optionA = optionA;
        this.optionB = optionB;
        this.optionC = optionC;
        this.optionD = optionD;
        if (correctAnswerLetter == 'A' || correctAnswerLetter == 'B' || correctAnswerLetter == 'C' || correctAnswerLetter == 'D') //validating correctAnswerLetter parameter
            this.correctAnswerLetter = correctAnswerLetter;
        else
            this.correctAnswerLetter = Question.defaultCorrectAnswerLetter; //defaultCorrectAnswerLetter is a static field
    }

    //A method that returns true, if at least two options are not null
    public bool AreOptionsValid()
    {
        return (optionA != null || optionB != null) && (optionC != null || optionD != null);
    }
}

class Program
{
    static void Main()
    {
        Question question1 = new Question(); //Create an object of Question class and pass no arguments to the constructor
        Question question2 = new Question("In which continent is costa rica situated?"); //Create an object of Question class and pass value for questionText only to the constructor.
        Question question3 = new Question("In which continent is costa rica situated?", "Asia", "North America", "South America", "Africa", 'B'); //Create an object of Question class and pass values for questionText, optionA, optionB, optionC, optionD and correctAnswerLetter to the constructor.
        Question question4 = new Question() { questionText = "In which continent is costa rica situated?", optionA = "Asia", optionB = "North America", optionC = "South America", optionD = "Africa" }; //Create an object for Question class and pass values for questionText, optionA, optionB, optionC, optionD only to the constructor.
    }
}

