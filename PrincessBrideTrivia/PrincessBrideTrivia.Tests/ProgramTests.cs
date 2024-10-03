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
    public void GetGameMode_ReturnsNormalMode()
    {
        // Arrange
        var input = new StringReader("1\n");
        Console.SetIn(input);
        // Act
        int result = Program.GetGameMode();
        // Assert
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void GetGameMode_ReturnsEasyMode()
    {
        // Arrange
        var input = new StringReader("2\n");
        Console.SetIn(input);
        // Act
        int result = Program.GetGameMode();
        // Assert
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void ReplayQuiz_ReturnsTrueIfUserPlaysAgain()
    {
        // Arrange
        var input = new StringReader("y\n");
        Console.SetIn(input);
        // Act
        bool result = Program.ReplayQuiz();
        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ReplayQuiz_ReturnsFalseIfUserDoesNotPlayAgain()
    {
        // Arrange
        var input = new StringReader("n\n");
        Console.SetIn(input);
        // Act
        bool result = Program.ReplayQuiz();
        // Assert
        Assert.IsFalse(result);
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
