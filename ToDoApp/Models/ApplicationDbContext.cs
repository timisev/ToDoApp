using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ToDoApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ToDo> ToDo { get; set; }
    }
}
