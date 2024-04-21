using Microsoft.EntityFrameworkCore;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Service;
using Movie_Net_Backend.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreService, GenreService>();

string connectionString = builder.Configuration.GetConnectionString("MySQLConnectionString")!;
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowLocalhost4200",
//         builder =>
//         {
//             builder.WithOrigins("http://localhost:4200")
//                 .AllowAnyHeader()
//                 .AllowAnyMethod();
//         });
// });


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