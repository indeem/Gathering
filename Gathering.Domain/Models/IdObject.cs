namespace Gathering.Domain.Models;

public class IdObject<TIdObject> : ValueObject
    where TIdObject : IdObject<TIdObject>
{
    protected IdObject(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static TIdObject Create()
    {
        return Activator.CreateInstance(typeof(TIdObject),
                   Guid.NewGuid()) as TIdObject ??
               throw new InvalidOperationException();
    }

    private static TIdObject Create(Guid value)
    {
        return Activator.CreateInstance(typeof(TIdObject),
                   value) as TIdObject ??
               throw new InvalidOperationException();
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator Guid(IdObject<TIdObject> idObject)
    {
        return idObject.Value;
    }

    public static implicit operator IdObject<TIdObject>(Guid value)
    {
        return Create(value);
    }
}