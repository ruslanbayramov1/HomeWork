using Microsoft.EntityFrameworkCore;
using UniqloMvc.Models;

namespace UniqloMvc.DataAccess
{
    public class UniqloDbContext : DbContext
    {
        public DbSet<Slider> Sliders { get; set; }

        public UniqloDbContext(DbContextOptions<UniqloDbContext> opt) : base(opt)
        {
            
        }
    }
}
