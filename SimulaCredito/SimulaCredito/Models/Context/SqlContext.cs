using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SimulaCredito.Models.Context
{
    public class SqlContext:DbContext
    {

        protected readonly IConfiguration Configuration;

        public SqlContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<TipoFinanciamento> TipoFinanciamento { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
    }

    
}
