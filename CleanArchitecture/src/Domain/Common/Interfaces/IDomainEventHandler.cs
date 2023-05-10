using MediatR;

namespace Domain.Common.Interfaces;
/// <summary>
/// Domain event handler - wraps the mediator notification handler to make app not fully dependent on MediatR
/// </summary>
/// <typeparam name="T">Type of DomainEvent to hook to</typeparam>
public interface IDomainEventHandler<T> : INotificationHandler<T> where T : IDomainEvent
{
}
