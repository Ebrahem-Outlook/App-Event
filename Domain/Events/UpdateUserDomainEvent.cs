using Domain.Core.Event;
using Domain.Entities;

namespace Domain.Events;

internal class UpdateUserDomainEvent : IDomainEvent
{
    /// <summary>
    /// Create Instance of the UpdateUserEvent.
    /// </summary>
    /// <param name="user">The User alreay updated in the memory.</param>
    public UpdateUserDomainEvent(User user)
    {
        User = user;
    }

    /// <summary>
    /// Get the already update in the memory
    /// </summary>
    public User User { get; }
}
