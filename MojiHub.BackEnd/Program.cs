using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MojiHub.BackEnd.Controllers;
using System.Text;
using MojiHub.Data.Services;
using MojiHub.BackEnd.Utility;
using MojiHub.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MojiHub.Data.Context;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
// تو بخش Services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", builder =>
    {
        builder.WithOrigins("https://localhost:7022") // آدرس Blazor
               .AllowAnyMethod() // اجازه به همه متدها (GET, POST, و غیره)
               .AllowAnyHeader(); // اجازه به همه هدرها
    });
});
#region IoC
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IViewRenderService, RenderViewToString>();

builder.Services.AddControllers();
#endregion

builder.Services.AddTransient<DbContext, DbContext>();

builder.Services.AddDbContext<MojiHubContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("newConnections")
));



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy
            .WithOrigins("https://trusted-client.com") // Replace 
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
        };
    });
builder.Services.AddScoped<IJwtService, JwtService>();
// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Add JWT support to Swagger UI
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });


    


    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddRazorPages();
var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Critical middleware order
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
app.UseCors("AllowBlazor"); 
app.UseAuthentication();

app.MapControllers();
app.Run();