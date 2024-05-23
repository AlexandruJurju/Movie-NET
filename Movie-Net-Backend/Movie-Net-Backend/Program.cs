using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Helper;
using Movie_Net_Backend.Service;
using Movie_Net_Backend.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

// setup jwt authentication
var jwtSecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// add swagger information
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie-Net-Backend", Version = "1.0" });
    c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["action"]}");
    c.AddServer(new OpenApiServer { Url = "http://localhost:5076", Description = "Local server" });
});

// add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<SmtpSettings>(options =>
{
    options.Host = Environment.GetEnvironmentVariable("SMTP_HOST");
    options.Port = int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT"));
    options.User = Environment.GetEnvironmentVariable("SMTP_EMAIL");
    options.Password = Environment.GetEnvironmentVariable("SMTP_PASSWORD");
    options.EmailFrom = Environment.GetEnvironmentVariable("SMTP_EMAIL_FROM");
});

// add services to DI
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IWatchlistService, WatchlistService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IJwtService, JwtService>();

// create mysql connection
var connectionString = builder.Configuration.GetConnectionString("MySQLConnectionString")!;
builder.Services.AddDbContext<AppDbContext>(
    options => options
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        // add lazy loading
        .UseLazyLoadingProxies());

// setup logging
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

// allow cors for frontend
app.UseCors(c =>
{
    c.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();