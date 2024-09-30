using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrincessBrideTrivia.Tests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void LoadQuestions_RetrievesQuestionsFromFile()
    {
        string filePath = Path.GetRandomFileName();
        try
        {
            // Arrange
            GenerateQuestionsFile(filePath, 2);

            // Act
            Question[] questions = Program.LoadQuestions(filePath);

            // Assert 
            Assert.AreEqual(2, questions.Length);
        }
        finally
        {
            File.Delete(filePath);
        }
    }

    [TestMethod]
    [DataRow("1", true)]
    [DataRow("2", false)]
    public void DisplayResult_ReturnsTrueIfCorrect(string userGuess, bool expectedResult)
    {
        // Arrange
        Question question = new();
        question.CorrectAnswerIndex = "1";

        // Act
        bool displayResult = Program.DisplayResult(userGuess, question);

        // Assert
        Assert.AreEqual(expectedResult, displayResult);
    }

    [TestMethod]
    public void GetFilePath_ReturnsFileThatExists()
    {
        // Arrange

        // Act
        string filePath = Program.GetFilePath();

        // Assert
        Assert.IsTrue(File.Exists(filePath));
    }

    [TestMethod]
    [DataRow(1, 1, "100%")]
    [DataRow(5, 10, "50%")]
    [DataRow(1, 10, "10%")]
    [DataRow(0, 10, "0%")]
    public void GetPercentCorrect_ReturnsExpectedPercentage(int numberOfCorrectGuesses, 
        int numberOfQuestions, string expectedString)
    {
        // Arrange

        // Act
        string percentage = Program.GetPercentCorrect(numberOfCorrectGuesses, numberOfQuestions);

        // Assert
        Assert.AreEqual(expectedString, percentage);
    }
    
    [TestMethod]
    [DataRow(10, 10, "What an amazing job! You're now a trivia master!")]
    [DataRow(8, 10, "Great job! It seems that you really know your stuff huh.")]
    [DataRow(5, 10, "Um :| keep practicing and you'll eventually get even better.")]
    [DataRow(3, 10, "Oh don't give up! Study up more and try again.")]
    public void DisplayMotivationalMessage_DisplaysCorrectMessage(int numberCorrect, int totalQuestions, string expectedMessage)
    {
        // Arrange
        StringWriter stringWriter = new StringWriter();
        Console.SetOut(stringWriter); // Redirects Console output to StringWriter

        // Act
        Program.DisplayMotivationalMessage(numberCorrect, totalQuestions);

        // Assert
        string output = stringWriter.ToString().Trim(); // Captures console output
        Assert.AreEqual(expectedMessage, output);
        
    }



    private static void GenerateQuestionsFile(string filePath, int numberOfQuestions)
    {
        for (int i = 0; i < numberOfQuestions; i++)
        {
            string[] lines =
            [
                "Question " + i + " this is the question text",
                "Answer 1",
                "Answer 2",
                "Answer 3",
                "2",
            ];
            File.AppendAllLines(filePath, lines);
        }
    }
}
