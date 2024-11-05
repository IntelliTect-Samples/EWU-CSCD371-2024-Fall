namespace GenericsAndStuff;

public interface IParser
{
    static abstract bool TryParse(string input, out object output);
}
