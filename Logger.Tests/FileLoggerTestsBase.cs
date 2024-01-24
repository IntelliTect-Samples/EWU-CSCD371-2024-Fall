namespace Logger.Tests;

public class FileLoggerTestsBase : IDisposable
{
    private bool disposedValue;

    protected string FilePath { get; set; }
    protected FileLogger Logger { get; set; }
    
    public FileLoggerTestsBase()
    {
        FilePath = Path.GetTempFileName();
        Logger = new FileLogger(nameof(FileLoggerTests), FilePath);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // Dispose managed state (managed objects)
                if (File.Exists(FilePath)) File.Delete(FilePath);
            }

            // Free unmanaged resources (unmanaged objects)
            // Set large fields to null
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
