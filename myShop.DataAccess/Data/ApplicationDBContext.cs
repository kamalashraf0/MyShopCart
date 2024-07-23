using Microsoft.EntityFrameworkCore;
using myShop.Entities.Models;


namespace myShop.DataAccess.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
    }
}
