using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

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
    public void ResetGame_1_True()
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
    public void ResetGame_Empty_False()
    {
        //Arrange
        var userInput = new StringReader("");

        //Act
        Console.SetIn(userInput);
        bool result = Program.ResetGame();

        //Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [DataRow("1", true)]
    [DataRow("2", false)]
    [DataRow("", false)]
    [DataRow("-1", false)]
    public void ResetGame_ValidInput_TrueOrFalse(string userInput, bool expectedResult)
    {
        //Arrange
        var input = new StringReader(userInput);
        Console.SetIn(input);

        //Act
        bool result = Program.ResetGame();

        //Assert
        Assert.AreEqual(expectedResult, result);

    }

    [TestMethod]
    public void LoadQuestions_RandomizesQuestions_ExpectArraysToBeDifferent()
    {
        // Arrange
        string filePath = Path.GetRandomFileName();
        try
        {
            GenerateQuestionsFile(filePath, 100);  
            Question[] firstLoad = Program.LoadQuestions(filePath);
            Question[] secondLoad = Program.LoadQuestions(filePath);

            // Act
            bool areDifferent = !Enumerable.SequenceEqual(
                firstLoad.Select(q => q.Text),
                secondLoad.Select(q => q.Text)
            );

            // Assert
            Assert.IsTrue(areDifferent, "The order of questions should be different between loads.");
        }
        finally
        {
            File.Delete(filePath);
        }
    }
}
