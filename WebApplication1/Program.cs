#region Using
using Application.EmailServices;
using Application.Hangfire;
using Application.ProfileMapper;
using AutoMapper;
using BookStore.Middlewares;
using BookStore.OptionsSetup.Email;
using BookStore.OptionsSetup.FireBase;
using BookStore.OptionsSetup.Jwt;
using Domain.InterfaceRebositorys;
using Domain.InterfaceRebositorys.UnitOfWork;
using Domain.InterfaceServices;
using Domain.Rebositorys;
using Hangfire;
using Infrastructure.Data;
using Infrastructure.EmailServices;
using Infrastructure.FirebaseServices;
using Infrastructure.Hangefire;
using Infrastructure.Repository;
using Infrastructure.Repository.UnitOfWork;
using Infrastructure.Services;
using Infrastructure.TokenServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
#endregion

#region Controller
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region Configuration
builder.Services.AddDbContext<ApplicationDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();
builder.Services.AddHttpContextAccessor();
#endregion

builder.Services.AddEndpointsApiExplorer();
#endregion

#region Scoop 
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IFireBaseServices, FireBaseServices>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IHangfireServices, Hangefireservices >();
builder.Services.AddScoped<IAuthenticatioService, AuthenticatioService>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUsersRepositroty, UsersRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBooksRepository, BooksRepository>();
builder.Services.AddScoped<IBooksServices, BookServices>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddHttpContextAccessor();
#endregion

#region set up
builder.Services.ConfigureOptions<FireBaseOptionsSetup>();
builder.Services.ConfigureOptions<EmailOptionsSetup>();
builder.Services.ConfigureOptions<JwtOptionSetup>();
builder.Services.ConfigureOptions<JwtBearerSetup>();
#endregion 

#region Jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "saif@alhara.com",
        ValidAudience = "BookUser",
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("lsa1Jxz+Jl8+5kP0g5YTJ23tVHZ6yQrVgGx/+Qj5gT8="))
    });
#endregion

#region Swager
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
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
#endregion

#region Mapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#region PipeLine
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandling>();
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseHangfireDashboard("/dashboard");

app.MapControllers();

app.Run();
#endregion