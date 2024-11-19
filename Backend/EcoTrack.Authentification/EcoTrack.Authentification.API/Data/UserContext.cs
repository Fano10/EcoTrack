using EcoTrack.Authentification.API.Model;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.Authentification.API.Data
{
    public class UserContext: DbContext
    {
        public virtual DbSet<User> Users { get; set; }
    }
}
