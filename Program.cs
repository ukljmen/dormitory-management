using DormAPI.Data;
using DormAPI.Data.Repository.Announcements;
using DormAPI.Data.Repository.DirectMessages;
using DormAPI.Data.Repository.Floors;
using DormAPI.Data.Repository.Items;
using DormAPI.Data.Repository.Problems;
using DormAPI.Data.Repository.Rooms;
using DormAPI.Models.Entities;
using DormAPI.Services.Announcements;
using DormAPI.Services.DirectMessages;
using DormAPI.Services.Floors;
using DormAPI.Services.Problems;
using DormAPI.Services.Rooms;
using DormAPI.Services.Users;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Zig");

builder.Services
    .AddDbContext<ApplicationDbContext>(options => 
        options.UseSqlServer(connectionString));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            AudienceValidator = null,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]!))
        };
    });

builder.Services
    .Configure<IdentityOptions>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 5;
        options.Password.RequiredUniqueChars = 1;
    });

var corsPolicy = "Default";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
            name: corsPolicy,
            builder =>
            {
                builder
                    .WithOrigins()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(config => true)
                    .AllowCredentials()
                    .Build();
            }
        );
});

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAnnouncementsRepository, AnnouncementsRepository>();
builder.Services.AddScoped<IAnnouncementsService, AnnouncementsService>();
builder.Services.AddScoped<IFloorsRepository, FloorsRepository>();
builder.Services.AddScoped<IFloorsService, FloorsService>();
builder.Services.AddScoped<IRoomsRepository, RoomsRepository>();
builder.Services.AddScoped<IRoomsService, RoomsService>();
builder.Services.AddScoped<IDirectMessagesRepository, DirectMessagesRepository>();
builder.Services.AddScoped<IDirectMessagesService, DirectMessagesService>();
builder.Services.AddScoped<IProblemsRepository, ProblemsRepository>();
builder.Services.AddScoped<IProblemsService, ProblemsService>();
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "DormAPI",
            Version = "v1"
        }
     );

    var filePath = Path.Combine(AppContext.BaseDirectory, "DormAPI.xml");
    c.IncludeXmlComments(filePath);

    c.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

app.UseCors(corsPolicy);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
