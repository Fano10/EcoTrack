using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EcoTrack.Authentification.API.ExtensionMethods
{
    public static class SecurityMethod
    {
        //Methode d'extension pour services pour parametrer le JWT
        public static void AddCustomAuthentification(this IServiceCollection services, IConfiguration configuration)
        {
            /*Configurer l'application pour qu'elle utilise JWT 
             * pour vérifier l'identité des utilisateurs sur toutes les requêtes(C'est seulement pour dire qu'
             * on va utiliser le JWT pour s'authentifier)*/
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //C'est ici que notre JWT va etre configurer
            }).AddJwtBearer(options =>
            {
                //fill with the key
                string maCle = "";
                //Cette option indique si le serveur doit conserver le jeton JWT dans l'objet utilisateur après authentification
                options.SaveToken = true;
                //Cette propriété définit les paramètres de validation que le serveur utilisera pour vérifier les jetons JWT
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    //Cette ligne indique la clé de signature que le serveur utilisera pour vérifier que le jeton JWT est valide
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(maCle)),
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateActor = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = "EcoTrackUsers",
                    ValidIssuer = "EcoTrackAuth",
                    ClockSkew = TimeSpan.Zero //evite les decalages de validation
                };
            });
        }
    }
}
