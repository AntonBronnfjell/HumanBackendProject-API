using Microsoft.EntityFrameworkCore;
using HumanAPI.Models;

namespace HumanAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Human> Humans { get; set; } = null!;
    }
}
