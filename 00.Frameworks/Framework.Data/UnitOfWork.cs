namespace Framework.Data;

public interface UnitOfWork
{
    Task Complete();
}