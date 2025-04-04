namespace BaseComponents.Core.Exceptions;

public class RoleValidationException : Exception
{
    public IRole Role { get; }

    public RoleValidationException(IRole role)
        : base(role.Message)
    {
        Role = role;
    }
}
