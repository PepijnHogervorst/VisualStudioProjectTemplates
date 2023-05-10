namespace Domain.Common.Interfaces;

/// <summary>
/// Abstracting application logic from DateTime.Now 
/// to be able to unit test properly and reliable
/// </summary>
public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}
