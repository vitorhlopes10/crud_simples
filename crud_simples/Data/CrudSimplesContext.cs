using crud_simples.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_simples.Data
{
    public class CrudSimplesContext : DbContext
    {
        public CrudSimplesContext(DbContextOptions<CrudSimplesContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> cliente { get; set; }
    }
}
