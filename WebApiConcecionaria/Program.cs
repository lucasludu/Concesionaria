using API.Core.Business.DBContext;
using API.Uses.Cases.UOWork;
using API.Uses.Cases.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using API.Core.Business.Filtros;
using Microsoft.AspNetCore.Mvc;
using API.Uses.Cases.Middleware;

var builder = WebApplication.CreateBuilder(args);

//------------------------------------------------------
//-------------------CONEXION A BBDD--------------------
//------------------------------------------------------

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql"), 
        b => b.MigrationsAssembly("WebApiConcecionaria"));
});

// UOWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Validacion Model State
builder.Services.AddScoped<ValidationFilterAttribute>();


builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

// Pasa los Enum a String
builder.Services.AddControllers().AddJsonOptions(x => {
    //serializa enums (Role) como string
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//------------------------------------------------------
//-------------------SWAGGER----------------------------
//------------------------------------------------------

#region SWAGGER
builder.Services.AddSwaggerGen(variable => {
    variable.SwaggerDoc("V1", new OpenApiInfo
    {
        Title = "Concecionaria",
        Description = "Gestion de stock y vetas",
        Version = "V1",
        Contact = new OpenApiContact
        {
            Name = "LucasLudu",
            Email = "lucas@gmail.com",
            Url = new Uri("https://www.google.com.ar/%22"),
        },
        License = new OpenApiLicense
        {
            Name = "",
            Url = new Uri("https://www.google.com.ar/%22"),
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    variable.IncludeXmlComments(xmlPath);

    variable.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    variable.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[]{}
        }
    });
});
#endregion SWAGGER

//------------------------------------------------------
//-----------------------JWT----------------------------
//------------------------------------------------------

#region JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        //ValidIssuer = builder.Configuration["Jwt:Issuing"],
        //ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))//secreto del appsetting.json
    };
});
#endregion JWT

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(variable => {
        variable.SwaggerEndpoint("/swagger/V1/swagger.json", "Concecionaria");
        variable.DefaultModelsExpandDepth(-1);
    });
}
// Middleware
app.UseMiddleware<EjemploMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();