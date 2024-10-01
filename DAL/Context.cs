using Microsoft.EntityFrameworkCore;
using JendriHidalgo_Ap1_P1.Models;

namespace JendriHidalgo_Ap1_P1.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> option) : base(option)
        {
        }

        public DbSet<Prestamo> Prestamo { get; set; }

    }
}
