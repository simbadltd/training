namespace TestTion.App.Persistence
{
    internal interface IDbContextFactory
    {
        RepositoryContext Create();
    }
}