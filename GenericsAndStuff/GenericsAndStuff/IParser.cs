namespace GenericsAndStuff;

public interface IParser<TOutput>
{
    static abstract bool TryParse(string input, out TOutput output);
}
