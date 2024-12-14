using EcoTrack.Authentification.API.Data;
using EcoTrack.Authentification.API.ExtensionMethods;
using EcoTrack.Authentification.API.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UserContext>(option =>
{
    //to fill with the connection string
    //for test purpose only, do not write directly the connexion string in the code in production
    option.UseNpgsql("Username =postgres; Password = Energizer12459; Host = localhost; Port = 1259; Database =EcoTrack; Pooling = true; Connection Lifetime =0;");
});
builder.Services.AddTransient<JwtService>();
builder.Services.AddTransient<HashService>();
builder.Services.AddCustomAuthentification(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDefaultCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(CorsMethod.DEFAULT_POLICY);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
