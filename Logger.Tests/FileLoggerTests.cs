﻿using Xunit;

namespace Logger.Tests;

public class FileLoggerTests : FileLoggerTestsBase
{    
    [Fact]
    public void CreateGivenClassAndValidFileNameSuccess()
    {
        Assert.Equal(nameof(FileLoggerTests), Logger.LogSource);
        Assert.Equal(FilePath, Logger.FilePath);
    }

    [Fact]
    public async Task LogMessageFileAppended()
    {
        Logger.Log(LogLevel.Error, "Message1");
        Logger.Log(LogLevel.Error, "Message2");

        string[] lines = await File.ReadAllLinesAsync(FilePath);
        Assert.True(lines is [..] and { Length: 2 });
        foreach (string[] line in lines.Select(line => line.Split(',', 4)))
        {
            if (line is [string dateTime, string source, string levelText, string message])
            {
                Assert.True(DateTime.TryParse(dateTime, out _));
                Assert.Equal(nameof(FileLoggerTests), source);
                Assert.True(Enum.TryParse(typeof(LogLevel), levelText, out object? level) ?
                    level is LogLevel.Error : false,"Level was not parsed successfully.");
            }
        }
    }
}
