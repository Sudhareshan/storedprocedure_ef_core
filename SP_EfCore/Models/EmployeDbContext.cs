using Microsoft.EntityFrameworkCore;

namespace SP_EfCore.Models
{
    public class EmployeDbContext:DbContext
    {
        public EmployeDbContext(DbContextOptions<EmployeDbContext> options):base(options) { 
        
        }
        public DbSet<Employe> employes { get; set; }
    }
}
