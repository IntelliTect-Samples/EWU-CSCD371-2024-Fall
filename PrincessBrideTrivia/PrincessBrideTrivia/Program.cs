namespace PrincessBrideTrivia;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = GetFilePath();
        Question[] questions = LoadQuestions(filePath);

        int numberCorrect = 0;
        int numberIncorrect = 0;
        for (int i = 0; i < questions.Length; i++)
        {
            bool result = AskQuestion(questions[i]);
            if (result)
            {
                numberCorrect++;
            }
            else
            {
                numberIncorrect++;
            }
        }
        
        
        // added a message to let the user know that the trivia has been completed along with some additional stats
        Console.WriteLine("\nYou have completed the trivia!");
        Console.WriteLine("Correct answers: " + numberCorrect);
        Console.WriteLine("Incorrect answers: " + numberIncorrect);
        Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");
        
        DisplayMotivationalMessage(numberCorrect, questions.Length);
    }

    public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
    {
        /*
         Casted the numerCorrectAnswers to a double value so we could a correct perentage value then casted
            the result back to an int
         */
        
        return (int)((double)numberCorrectAnswers / numberOfQuestions * 100) + "%";
    }

    public static bool AskQuestion(Question question)
    {
        DisplayQuestion(question);

        string userGuess = GetGuessFromUser();
        return DisplayResult(userGuess, question);
    }

    public static string GetGuessFromUser()
    {
        return Console.ReadLine();
    }

    public static bool DisplayResult(string userGuess, Question question)
    {
        if (userGuess == question.CorrectAnswerIndex)
        {
            Console.WriteLine("Correct");
            return true;
        }

        Console.WriteLine("Incorrect");
        return false;
    }
    
    /*
        Created the DisplayMotivationalMessage method as "feature request"
        it takes the # of correct answers and divides it from the number 
        of total answers and based on the result it displays a motivational 
        message
     */
    public static void DisplayMotivationalMessage(int numberCorrect, int totalQuestions)
    {
        double percentage = (double)numberCorrect / totalQuestions * 100;

        if (percentage == 100)
        {
            Console.WriteLine("What an amazing job! You're now a trivia master!");
        }
        else if (percentage >= 80)
        {
            Console.WriteLine("Great job! It seems that you really know your stuff huh.");
        }
        else if (percentage >= 50)
        {
            Console.WriteLine(" Um :| keep practicing and you'll eventually get even better.");
        }
        else
        {
            Console.WriteLine("Oh don't give up! Study up more and try again.");
        }
    }

    public static void DisplayQuestion(Question question)
    {
        Console.WriteLine("Question: " + question.Text);
        for (int i = 0; i < question.Answers.Length; i++)
        {
            Console.WriteLine((i + 1) + ": " + question.Answers[i]);
        }
    }

    public static string GetFilePath()
    {
        return "Trivia.txt";
    }

    public static Question[] LoadQuestions(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        Question[] questions = new Question[lines.Length / 5];
        for (int i = 0; i < questions.Length; i++)
        {
            int lineIndex = i * 5;
            string questionText = lines[lineIndex];

            string answer1 = lines[lineIndex + 1];
            string answer2 = lines[lineIndex + 2];
            string answer3 = lines[lineIndex + 3];

            string correctAnswerIndex = lines[lineIndex + 4];

            Question question = new();
            question.Text = questionText;
            question.Answers = new string[3];
            question.Answers[0] = answer1;
            question.Answers[1] = answer2;
            question.Answers[2] = answer3;
            question.CorrectAnswerIndex = correctAnswerIndex;
            
            // The questions weren't being stored for future use so we created an array to store the questions w/ answers
            questions[i] = question;
        }
        return questions;
    }
}
