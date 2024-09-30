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
    public void ProgramAsksToRetakeQuizAfterCompletion()
    {
        // Arrange
        var input = new StringReader("1\nn\n"); // Simulate answering one question and then selecting 'n'
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        Program.Main(new string[] { });

        // Assert
        var result = output.ToString();
        // Ensure the retake question is in the output
        Assert.IsTrue(result.Contains("Do you want to retake the quiz? (y/n)"), "Retake prompt not found in output.");
    }

    [TestMethod]
    public void ProgramRestartsOnYInput()
    {
        // Arrange
        var input = new StringReader("1\ny\n1\nn\n"); // Simulate answering, then retaking, then exiting
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        Program.Main(new string[] { });

        // Assert
        string result = output.ToString();
        int firstQuizStartIndex = result.IndexOf("Question: ");
        int secondQuizStartIndex = result.LastIndexOf("Question: ");
        Assert.AreNotEqual(firstQuizStartIndex, secondQuizStartIndex, "Quiz did not restart.");
    }

    /*
    [TestMethod]
    public void ProgramExitsOnNInput()
    {
        // Arrange
        var input = new StringReader("1\nn\n"); // Simulate answering one question, then selecting 'n' to exit
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        Program.Main(new string[] { });

        // Assert
        string result = output.ToString();

        // Ensure the program did not restart the quiz after selecting 'n'
        int firstQuizStartIndex = result.IndexOf("Question: ");
        int secondQuizStartIndex = result.LastIndexOf("Question: ");

        Assert.AreEqual(firstQuizStartIndex, secondQuizStartIndex, "The quiz restarted even after choosing 'n'.");
    }

    [TestMethod]
    public void ProgramPromptsAgainOnInvalidInput()
    {
        // Arrange
        var input = new StringReader("1\nz\ny\n"); // Simulate invalid input and then valid input
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        Program.Main(new string[] { });

        // Assert
        string result = output.ToString();
        Assert.IsTrue(result.Contains("Invalid input, please enter 'y' or 'n'."), "Invalid input message not found.");
        Assert.IsTrue(result.Contains("Do you want to retake the quiz? (y/n)"), "Retake prompt not repeated after invalid input.");
    }
    */

}
