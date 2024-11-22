namespace Assignment;

public abstract class SampleDataBase
{
    protected string FileName { get; }

    protected SampleDataBase(string fileName)
    {
        FileName = fileName;
        if (!File.Exists(FileName))
        {
            throw new FileNotFoundException($"File not found: {FileName}");
        }
    }

    protected string ValidateAndReadHeader()
    {
        string header = File.ReadLines(FileName).First();
        CsvHelper.ValidateHeader(header);
        return header;
    }
}