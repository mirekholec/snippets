public class AppDbContextDesignTime : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=efcore;User Id=sa;Password=pass;Integrated Security=false;");
        
        AppDbContext appDbContext = new AppDbContext(optionsBuilder.Options);

        return appDbContext;
    }
}