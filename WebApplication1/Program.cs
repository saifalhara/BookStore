using Application.EmailServices;
using Application.ProfileMapper;
using Appwrite;
using AutoMapper;
using BookStore.Middlewares;
using BookStore.OptionsSetup.Email;
using BookStore.OptionsSetup.FireBase;
using BookStore.OptionsSetup.Jwt;
using Domain.InterfaceRebositorys;
using Domain.InterfaceRebositorys.UnitOfWork;
using Domain.InterfaceServices;
using Domain.Rebositorys;
using Infrastructure.Data;
using Infrastructure.EmailServices;
using Infrastructure.Repository;
using Infrastructure.Repository.UnitOfWork;
using Infrastructure.Services;
using Infrastructure.TokenServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IFireBaseServices, FireBaseServices>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IAuthenticatioService, AuthenticatioService>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBooksRepository, BooksRepository>();
builder.Services.AddScoped<IBooksServices, BookServices>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureOptions<FireBaseOptionsSetup>();
builder.Services.ConfigureOptions<EmailOptionsSetup>();
builder.Services.ConfigureOptions<JwtOptionSetup>();
builder.Services.ConfigureOptions<JwtBearerSetup>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

//var client = new Client();
//client
//    .SetEndpoint("https://cloud.appwrite.io/v1")
//    .SetProject("66631a6e00303f28c12f")
//    .SetKey("84bc276c10802950cbdc175a1de912ac2991b4238f0770bf71469de55f5f50de3b83a8df22b69cab3b4c51c572a3b73bed6d1f21ae1e8a611bdc836f6a99eb4859be656429ef273779344e6d109bc4a60e9a5bcf83a2eab4d523a37a910f53cc5cd2abe1fe7014eeaf676ace652c84a1bd6d0703f3d1cffe7a3efba2434f5a1a");

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
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
                new string[] {}
            }
        });
});

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddSwaggerGen();

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

app.MapControllers();

app.Run();
