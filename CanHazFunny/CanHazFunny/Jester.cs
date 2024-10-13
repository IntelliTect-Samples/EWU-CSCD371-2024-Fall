
namespace CanHazFunny;

internal class Jester
{
    private readonly IJokeService JokeService;
    private readonly IJokeTeller JokeTeller;

    public Jester(IJokeService jokeService, IJokeTeller jokeTeller)
    {
        JokeService = jokeService;
        JokeTeller = jokeTeller;
    }

    public void TellJoke()
    {
        
    }
}
