using Microsoft.EntityFrameworkCore;

namespace ServerApp.Data
{
    public class SocialContext: DbContext
    {
        public SocialContext(DbContextOptions<SocialContext> options): base(options)
        {
            
        }
    }
}