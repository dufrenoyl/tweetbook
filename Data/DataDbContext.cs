using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TweetBook.Data
{
    public class DataDbContext : IdentityDbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options)
            : base(options)
        {
        }
    }
}