using MediatR;

namespace Domain.Common.Interfaces;
/// <summary>
/// Domain event for loosely couples events in backend (and front-end). 
/// Wraps MediatR package to prevent fully dependent app on that package
/// </summary>
public interface IDomainEvent : INotification
{
}