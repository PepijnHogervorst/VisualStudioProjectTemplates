namespace Domain.Common.Interfaces;
/// <summary>
/// Startup initializer that is executed in order
/// Order 0 is highest priority
/// (Dynamically added to DI using assembly scanning)
/// </summary>
public interface IStartupInitializer
{
    int Order { get; }
    Task Initialize();
}
