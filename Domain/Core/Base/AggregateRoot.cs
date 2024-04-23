using Domain.Core.Event;
using System.Xml.Serialization;

namespace Domain.Core.Base;

/// <summary>
/// Represint the AggregateRoot Base Class for all Aggregate in the system
/// </summary>
public abstract class AggregateRoot : Entity
{
    /// <summary>
    /// Create new instance of AggregateRoot BaseClass
    /// </summary>
    /// <param name="id"></param>
    protected AggregateRoot(Guid id) : base(id) { }

    protected AggregateRoot() { }

    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

    /// <summary>
    /// Get The ReadOnly Collection of the DomainEvents.
    /// </summary>
    protected IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Delete All Event in the DomainEvent Collection.
    /// </summary>
    public void ClearDomainEvent() => _domainEvents.Clear();

    /// <summary>
    /// Add New DomianEvent to the Collection.
    /// </summary>
    /// <param name="event"></param>
    public void AddDomianEvent(IDomainEvent @event) => _domainEvents.Add(@event);
}
