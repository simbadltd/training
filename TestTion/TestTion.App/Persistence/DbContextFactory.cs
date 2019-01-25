namespace TestTion.App.Persistence
{
    internal sealed class DbContextFactory : IDbContextFactory
    {
        public RepositoryContext Create()
        {
            return new RepositoryContext("Data Source=localhost;Initial Catalog=test;User Id=sa;Password=123;");
        }
    }
}