using EcoTrack.SuiviEmpreinteCarbone.API.Data;
using EcoTrack.SuiviEmpreinteCarbone.API.Model;
using System.Globalization;

namespace EcoTrack.SuiviEmpreinteCarbone.API.Service
{
    public class UserService
    {
        private readonly UserContext userContext;

        public UserService( UserContext context)
        {
            userContext = context;
        }

        public int UserFinding(string sub, string name)
        {
            User? user = userContext.Users.FirstOrDefault(x => x.Sub == sub); 
            if (user == null)
            {
                userContext.Users.Add(new User { Sub = sub, Name = name });
                userContext.SaveChanges();
                return -1;
            }
            return user.Id;
        }
    }
}
