using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PPI_Challenge_API.Endpoints;
using PPI_Challenge_API.Services.Implementations;
using PPI_Challenge_API.Services.Interfaces;
using PPI_Challenge_API.Utilities;
using PPI_Challenge_API;
using Microsoft.AspNetCore.Diagnostics;
using PPI_Challenge_API.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexión a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("name=DefaultConnection"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true; 
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true; 
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddOutputCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddProblemDetails();

builder.Services.AddAuthentication(options =>
{
    // foro  https://learn.microsoft.com/en-us/answers/questions/2136683/issue-with-405-method-not-allowed-instead-of-401-u
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.MapInboundClaims = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKeys = KeysHandler.GetAllKeys(builder.Configuration)
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("isadmin", policy => policy.RequireClaim("isadmin"));
});



var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp => exceptionHandlerApp.Run(async context =>
{
    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
    var exception = exceptionHandlerFeature?.Error;

    if (exception != null)
    {
        // Log con Serilog

        // Crear un objeto de error para almacenar en la base de datos
        var error = new Error
        {
            Date = DateTime.UtcNow,
            ErrorMessage = exception.Message,
            StackTrace = exception.StackTrace
        };

        // Guardar el error en la base de datos
        //var repository = context.RequestServices.GetRequiredService<IErrorsRepository>();
        //await repository.Create(error);

        // Devolver la respuesta JSON con código de error 500
        await Results.Json(new
        {
            type = "error",
            message = "An unexpected exception has occurred",
            status = 500
        }).ExecuteAsync(context);
    }
}));
app.UseSwagger();
app.UseSwaggerUI();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseOutputCache();
app.UseAuthorization();

app.MapGroup("account").MapAccount();

app.Run();
