using Microsoft.Extensions.Logging;

namespace Console.Services.Sample;

public class GreetingService : IGreetingService
{
    private readonly ILogger<GreetingService> _log;

    public GreetingService(ILogger<GreetingService> log)
    {
        _log = log;
    }

    public void Run()
    {
        System.Console.WriteLine($"Hello there developer! Replace this class with your own console program!");
        System.Console.WriteLine($"Press a key to close down console..");
        System.Console.ReadKey();
    }
}
