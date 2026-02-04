using AlhadiLibrary.DataAccess.Repo.EfCore;
using AlhadiLibrary.Db.SqlServer.EfCore.DbContext;
using AlhadiLibrary.Db.SqlServer.EfCore.Identity.Service;
using AlhadiLibrary.Domain.AppService._common;
using AlhadiLibrary.Domain.AppService.Comments.Commands.Create;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.CommentAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.CommentAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.UserAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.UserAgg.Entities;
using AlhadiLibrary.Domain.Service;
using AlhadiLibrary.Presentation_WebApi.CustomMiddleware;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
    {
        options.Password.RequiredLength = 6;
        options.Password.RequireDigit = true;
        options.Password.RequireNonAlphanumeric = false;
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ??
                    throw new InvalidOperationException("JWT Key is not configured")))
        };
    });

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(
        typeof(CreateCommentCommand).Assembly);
});

builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>)
);

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Alhadi Library API",
        Version = "v1",
        Description = "CQRS + MediatR + JWT Authentication",
        Contact = new OpenApiContact
        {
            Name = "Alhadi Team",
            Email = "support@alhadi.ir"
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header.\r\n\r\n" +
            "Enter your token like this:\r\n" +
            "**Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...**"
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

builder.Services.AddValidatorsFromAssembly(
    typeof(CreateCommentCommandValidator).Assembly);


builder.Services.AddAutoMapper(
    AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

var app = builder.Build();
app.UseMiddleware<RequestLoggingMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
