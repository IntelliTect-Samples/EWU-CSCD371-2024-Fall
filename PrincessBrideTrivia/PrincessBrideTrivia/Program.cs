﻿namespace PrincessBrideTrivia;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = GetFilePath();
        Question[] questions = LoadQuestions(filePath);

        int numberCorrect = 0;
        bool playAgain = true;

        while (playAgain)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                bool result = AskQuestion(questions[i]);
                if (result)
                {
                    numberCorrect++;
                }
            }

            Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct.");
            playAgain = ResetGame();
            numberCorrect = 0;
        }
    }

    public static bool ResetGame()
    {
        Console.Write("Type 1 if you would like to play again: ");

        string userInput = Console.ReadLine();
        int choice;

        if (int.TryParse(userInput, out choice))
        {
            if (choice == 1)
            {
                return true;
            }
        }
        return false;
    }

    public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
    {
        double percent = (numberCorrectAnswers / (double)numberOfQuestions * 100);
        return $"{percent:0.##}%";
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

    public static string GetFilePath()
    {
        return "Trivia.txt";
    }

    public static Question[] LoadQuestions(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        Random random = new Random();
        
        Question[] questions = new Question[lines.Length / 5];
        int randomNumber = random.Next(0, questions.Length);
        int tracker = randomNumber;

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
            questions[tracker % questions.Length] = question;
            tracker++;
        }
        return questions;
    }
}
