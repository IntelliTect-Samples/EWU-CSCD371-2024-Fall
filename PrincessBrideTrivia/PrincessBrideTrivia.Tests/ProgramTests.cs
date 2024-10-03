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

    [DataRow("y",true)]
    [DataRow("n", false)]
    public void RestartQuiz_ReturnsExpected(String userInput,bool expected)
    {
        var reader = new StringReader(userInput);
        //arrange
        bool returnVar;
        Console.SetIn(reader);
        //act
        returnVar = Program.RestartQuiz();
        //assert
        Assert.AreEqual(returnVar,expected,"Method returned: "+returnVar+ " expected: "+expected);
    }

    [TestMethod]
    public void ProgramAsksToRetakeQuizAfterCompletion()
    {
        // Arrange
        var input = new StringReader("1\n1\n1\n1\n1\n1\n1\nn\n"); // Simulate answering all questions and then selecting 'n'
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        Program.Main(new string[] { });

        // Assert
        var result = output.ToString();
        // Ensure the retake question is in the output
        Assert.IsTrue(result.Contains("Do you want to retake the quiz? (y/n)"));
    }

    [TestMethod]
    public void ProgramRestartsOnYInput()
    {
        // Arrange
        var input = new StringReader("1\n1\n1\n1\n1\n1\n1\ny\n"); // Simulate answering, then retaking, then exiting
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        Program.Main(new string[] { });

        // Assert
        string result = output.ToString();
        int lineCount = result.Split("Question: ").Length;
        Assert.IsTrue(lineCount > 8, "Expected more than 8 questions but got "+lineCount);
        Assert.IsTrue(result.Contains("Retaking Quiz"));
    }

    
    [TestMethod]
    public void ProgramExitsOnNInput()
    {
        // Arrange
        var input = new StringReader("1\n1\n1\n1\n1\n1\n1\nn\n"); // Answer all questions then opt to quit quiz with 'n'
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        Program.Main(new string[] { });

        // Assert
        string result = output.ToString();
        Console.WriteLine(result);

        // Ensure the program ends on N
        Assert.IsFalse(result.Contains("Retaking Quiz"),result);

        

    }

    [TestMethod]
    public void ProgramPromptsAgainOnInvalidInput()
    {
        // Arrange
        var input = new StringReader("1\n1\n1\n1\n1\n1\n1\nz\nn\n"); // Simulate invalid input and then valid input
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
    

}
