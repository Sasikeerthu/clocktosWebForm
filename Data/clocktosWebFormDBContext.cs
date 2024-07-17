using clocktosWebForm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace clocktosWebForm.Data
{
    public class clocktosWebFormDBContext : DbContext
    {
        public clocktosWebFormDBContext(DbContextOptions<clocktosWebFormDBContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}