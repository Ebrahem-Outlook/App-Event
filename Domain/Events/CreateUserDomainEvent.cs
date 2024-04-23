using Domain.Core.Event;
using Domain.Entities;

namespace Domain.Events;

internal class CreateUserDomainEvent : IDomainEvent
{
    /// <summary>
    /// Create Instance of CreateUserEvent.
    /// </summary>
    /// <param name="user">The User alreay Created in the memory.</param>
    public CreateUserDomainEvent(User user)
    {
        User = user;
    }

    /// <summary>
    /// Get the new User Already Created.
    /// </summary>
    public User User { get; }
}
