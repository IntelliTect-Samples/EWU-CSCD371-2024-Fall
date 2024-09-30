using Microsoft.VisualBasic;
using System.Net.NetworkInformation;

namespace PrincessBrideTrivia;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = GetFilePath();
        Question[] questions = LoadQuestions(filePath);

        int numberCorrect = 0;
        int numberStreaks = 0;
        int highestStreak = 0;
        for (int i = 0; i < questions.Length; i++)
        {
            bool result = AskQuestion(questions[i]);
            if (result)
            {
                numberCorrect++;
                numberStreaks++;
                AnswerStreak(result, numberStreaks);
            }
            else 
            {
                if (numberStreaks > highestStreak)
                {
                    highestStreak = numberStreaks;
                }
                numberStreaks = 0;
                AnswerStreak(result, numberStreaks);

            }
        }
        Console.WriteLine("Your highest streaks is " + highestStreak);
        Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");
    }

    public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
    {
        return ((double)numberCorrectAnswers / numberOfQuestions * 100) + "%";
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

    public static void DisplayQuestion(Question question)
    {
        Console.WriteLine("Question: " + question.Text);
        for (int i = 0; i < question.Answers.Length; i++)
        {
            Console.WriteLine((i + 1) + ": " + question.Answers[i]);
        }
    }

    public static void AnswerStreak(bool CorrectAnswer, int numberStreaks)
    {
        if (CorrectAnswer)
        {
            switch (numberStreaks)
            {
                case 1:
                    Console.WriteLine("Good choice! You've earned a streak!");
                    break;
                case 2:
                    Console.WriteLine("That was a sharp decision. You’ve earned a streak!");
                    break;
                case 3:
                    Console.WriteLine("Great thinking! You've earned a streak with style!");
                    break;
                case 4:
                    Console.WriteLine("Brilliant choice! You've earned a well-deserved streak!");
                    break;
                case 5:
                    Console.WriteLine("You've made a bold, epic choice! A streak is yours!");
                    break;
                case 6:
                    Console.WriteLine("You have chosen... wisely. You've earned a streak like a legend!");
                    break;
                default:
                    Console.WriteLine("You've earned a streak!");
                    break;
            }
        }
        else 
        {
            Console.WriteLine("You have chosen... poorly. Your streaks is now gone!");
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

            questions[i] = question;
        }
        return questions;
    }
}
