using Microsoft.EntityFrameworkCore;
using schollApp.Models;

namespace schollApp.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Usuario> usuario { get; set; }
    }
}
