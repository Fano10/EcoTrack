using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.SuiviEmpreinteCarbone.API.Data
{
    public class UserContextFactory : IDesignTimeDbContextFactory<UserContext>
    {
        public UserContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<UserContext>();
            optionBuilder.UseNpgsql("");

            return new UserContext(optionBuilder.Options);
        }
    }
}
