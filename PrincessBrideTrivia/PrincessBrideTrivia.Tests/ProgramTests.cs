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

    [TestMethod]
    public void RessetingTheGame()
    {
        //Arrange
        var userInput = new StringReader("1");

        //Act
        Console.SetIn(userInput);
        bool result = Program.ResetGame();

        //Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void EndingTheGame()
    {
        //Arrange
        var userInput = new StringReader("");

        //Act
        Console.SetIn(userInput);
        bool result = Program.ResetGame();

        //Assert
        Assert.IsFalse(result);
    }
}
