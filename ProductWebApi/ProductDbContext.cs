using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProductWebApi.Model;

namespace ProductWebApi
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            try
            {
                var dataBaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (dataBaseCreator != null)
                {
                    if (!dataBaseCreator.CanConnect()) dataBaseCreator.Create();
                    if (!dataBaseCreator.HasTables()) dataBaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public DbSet<Product> Products { get; set; }
    }
}
