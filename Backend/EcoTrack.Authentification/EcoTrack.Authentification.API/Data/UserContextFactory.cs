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
            //for test purpose only, do not write directly the connexion string in the code in production
            optionBuilder.UseNpgsql("Username =postgres; Password = Energizer12459; Host = localhost; Port = 1259; Database =EcoTrack; Pooling = true; Connection Lifetime =0;");

            return new UserContext(optionBuilder.Options); 
        }
    }
}
