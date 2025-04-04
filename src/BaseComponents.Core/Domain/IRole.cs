namespace BaseComponents.Core.Domain;

public interface IRole
{
    string Message { get; }

    bool Invalid();
}
