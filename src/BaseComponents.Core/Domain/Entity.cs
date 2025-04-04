namespace BaseComponents.Core.Domain;

public abstract class Entity
{
    int? _requestedHashCode;

    Guid _Id = Guid.NewGuid();

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? RemovedAt { get; set; }

    public virtual Guid Id
    {
        get
        {
            return _Id;
        }
        protected set
        {
            Guard.IsNull(value, "Id can not be null");

            _Id = value;
        }
    }

    private readonly List<IEvent> _domainEvents = [];

    public IReadOnlyCollection<IEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(IEvent eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not Entity)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (GetType() != obj.GetType())
            return false;

        Entity item = (Entity)obj;

        return item.Id == Id;
    }

    public override int GetHashCode()
    {
        if (!_requestedHashCode.HasValue)
            _requestedHashCode = Id.GetHashCode() ^ 31;

        return _requestedHashCode.Value;
    }
    public static bool operator ==(Entity left, Entity right)
    {
        if (Equals(left, null))
            return Equals(right, null);
        else
            return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }

    protected static void CheckRole(IRole role)
    {
        if (role.Invalid())
        {
            throw new RoleValidationException(role);
        }
    }
}