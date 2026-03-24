using Microsoft.EntityFrameworkCore;
using CrudComAngular.Models;

namespace CrudComAngular.Data
{
    public class AppDbContext:DbContext
    {
        public  AppDbContext(DbContextOptions <AppDbContext> options) : base(options){}
        public DbSet<Colaborador> Colaboradores  { get; set; }
    
       
    }
}