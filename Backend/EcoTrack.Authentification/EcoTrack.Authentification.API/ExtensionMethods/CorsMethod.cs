namespace EcoTrack.Authentification.API.ExtensionMethods
{
    public static class CorsMethod
    {
        public const string DEFAULT_POLICY = "DEFAULT_POLICY";

        public static void AddDefaultCors (this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_POLICY, builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
            });
        }
    }
}
