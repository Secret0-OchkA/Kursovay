using Context;
using DockerTestBD.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new OpenApiInfo
        {
            Contact = new OpenApiContact
            {
                Name = "Secretochka",
                Email = "ne bydet",
                Url = new Uri("https://github.com/Secret0-OchkA"),
            },
            Title = "My API - V1",
            Version = "v1"
        });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContextFactory<ApplicationDbContext, ApplicationDbContextFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)// remove "|| true" to be without swaggerUI
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder.AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
