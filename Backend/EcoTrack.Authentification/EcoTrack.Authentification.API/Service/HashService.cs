namespace EcoTrack.Authentification.API.Service
{
    public class HashService
    {
        public string CreateHashPassword(string password)
        {
            string hash2b = BCrypt.Net.BCrypt.HashPassword(password);
            return hash2b;
        }
        public bool VerifyPassword(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }
    }
}
