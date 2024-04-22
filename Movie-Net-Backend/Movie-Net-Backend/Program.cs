using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Service;
using Movie_Net_Backend.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie-Net-Backend", Version = "1.0" });
    c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["action"]}");
    c.AddServer(new OpenApiServer { Url = "http://localhost:5076", Description = "Local server" });
});

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IActorService, ActorService>();

string connectionString = builder.Configuration.GetConnectionString("MySQLConnectionString")!;
builder.Services.AddDbContext<AppDbContext>(
    options => options
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        .UseLazyLoadingProxies());

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();