using CustomerWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerWebApi
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> dbContextOptions) : base(dbContextOptions)
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

		public DbSet<Customer> Customers { get; set; }
	}
}
