using Application.UserService.Interfaces;
using Application.UserService.Services;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Data.Config;
using Infrastructure.Persistence.Repository;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//step-1
builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        //Don't Apply default camelCaseNamingPolicy to names of properites of instances
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//step-2
builder.Services.AddSwaggerGen(c => {
    //Documentation of swagger application
    c.SwaggerDoc("PMS_Swagger", new OpenApiInfo
    {
        Title = "Parking Management System",
    });
    //Adds scheme required for Authorization
    c.AddSecurityDefinition("PMS JWT Authentication",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
    //adds Authorization requirements  for Controller/Methods
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "PMS JWT Authentication"
                }
            },
            Array.Empty<string>()
        }
    });
});

//step 3
//Add services required for Authentication
builder.Services.AddAuthentication("Bearer").

    // Enables JWT Authentication using Bearer scheme
    AddJwtBearer(options =>
    {
        // Set parameters for validating tokens
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:issuer"],
            ValidAudience = builder.Configuration["Jwt:audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!))
        };
    }
);

//Mapping the Interface and its concrete classes
builder.Services.AddScoped<IPMSConfiguration, DapperDbContext>();
builder.Services.AddSingleton<DapperDbContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
         c => c.SwaggerEndpoint("/swagger/PMS_Swagger/swagger.json", "Parking Management System")
        );
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
