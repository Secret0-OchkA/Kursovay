using App.Metrics;
using App.Metrics.Extensions.Configuration;
using Context;
using DockerTestBD.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
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

var configuratino = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var metricBuilder = new MetricsBuilder()
    .Configuration.ReadFrom(configuratino)
    .OutputMetrics.AsPrometheusPlainText();
builder.Services.AddMetrics(metricBuilder);
builder.Services.AddMetricsEndpoints(configuratino);
builder.Services.AddMvcCore().AddMetricsCore();
builder.Services.AddMetricsTrackingMiddleware(configuratino);

var app = builder.Build();

app.UseMetricsEndpoint();
app.UseMetricsRequestTrackingMiddleware();
app.UseMetricsAllEndpoints();

app.UseCors(builder => {
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
});
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
