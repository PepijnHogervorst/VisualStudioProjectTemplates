using Domain.Common.Interfaces;

namespace Infrastructure.Services.Utility;

/// <summary>
/// Used to be able to mock DateTime.Now / DateTimeOffset.Now
/// </summary>
internal class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}
