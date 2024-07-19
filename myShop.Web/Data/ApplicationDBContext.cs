using Microsoft.EntityFrameworkCore;
using myShop.Web.Models;

namespace myShop.Web.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
    }
}
