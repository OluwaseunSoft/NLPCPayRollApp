using Microsoft.EntityFrameworkCore;
using NLPCPayRollApp.Models;

namespace NLPCPayRollApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<CadreLevel> CadreLevels { get; set; }
        public DbSet<PayrollComponents> PayrollComponents { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
