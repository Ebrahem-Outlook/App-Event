
namespace Domain.Core.Base;

/// <summary>
/// Represinte the entity base class for entity in the system
/// </summary>
public abstract class Entity : IEquatable<Entity?>
{
    /// <summary>
    /// Create new instance of entity base class
    /// </summary>
    /// <param name="id">the identifier of entity</param>
    protected Entity(Guid id) => Id = id;

    /// <summary>
    /// Get and Set the identifier of the entity.
    /// </summary>
    protected Guid Id { get; private set; }

    /// <summary>
    /// Required by EF Core.
    /// </summary>
    protected Entity() { }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity);
    }

    public bool Equals(Entity? other)
    {
        return other is not null &&
               Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public static bool operator ==(Entity? left, Entity? right)
    {
        return EqualityComparer<Entity>.Default.Equals(left, right);
    }

    public static bool operator !=(Entity? left, Entity? right)
    {
        return !(left == right);
    }
}
