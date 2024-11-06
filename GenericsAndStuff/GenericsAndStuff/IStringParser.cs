namespace GenericsAndStuff;

public interface IStringParser<TOutput>
{
    static abstract bool TryParse(string input, out TOutput output);
}

public interface IParser<TOutput>
{
    bool TryParse(string input, out TOutput? output);
}
