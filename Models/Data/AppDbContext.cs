using Microsoft.EntityFrameworkCore;
using MvcBusinessManagement.Models;

namespace MvcBusinessManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //table name
        public DbSet<ManagementModel> Management { get; set; }
    }
}