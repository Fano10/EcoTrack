using EcoTrack.Authentification.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EcoTrack.Authentification.API.Data
{
    public class UserContextFactory : IDesignTimeDbContextFactory<UserContext>
    {
        public UserContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<UserContext>();
            optionBuilder.UseNpgsql();

            return new UserContext(optionBuilder.Options); 
        }
    }
}
