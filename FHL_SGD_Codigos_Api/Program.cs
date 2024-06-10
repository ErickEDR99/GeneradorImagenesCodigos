using Codigos.Modelo.Entidades.Despachos;
using Codigos.Negocio.Contratos.Common;
using Codigos.Negocio.Contratos.Despachos;
using Codigos.Negocio.Negocios;
using Codigos.Negocio.Negocios.Common;
using Codigos.Negocio.Negocios.Despachos;
using Codigos.Repositorio.Contratos.Common;
using Codigos.Repositorio.Contratos.Despachos;
using Codigos.Repositorio.Repositorios.Common;
using Codigos.Repositorio.Repositorios.Despachos;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Reflection;
using System.Text.Json.Serialization;

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => {
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("ValidadorNuevosRegistros", new OpenApiInfo
    {
        Title = "Validador de nuevos registros de SGD",
        Description = "Una Web API de ASP.NET Core para gestionar las validaciones de nuevos registros de SGD"
    });
    c.SwaggerDoc("Colaboradores", new OpenApiInfo
    {
        Title = "Colaboradores SGD",
        Description = "Una Web API de ASP.NET Core para gestionar SGD"
    });
    c.SwaggerDoc("Componentes", new OpenApiInfo
    {
        Title = "Componentes SGD",
        Description = "Una Web API de ASP.NET Core para gestionar SGD"
    });
    c.SwaggerDoc("Despachos", new OpenApiInfo
    {
        Title = "Despachos SGD",
        Description = "Una Web API de ASP.NET Core para gestionar SGD"
    });
    // Configuración para incluir comentarios XML de documentación
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    // Limita la cantidad de información generada
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
}
);

//Creación de instancias para que las clases sean alcanzables
builder.Services.AddScoped<ITicketRepositorio, TicketRepositorio>();
builder.Services.AddScoped<ITicketBusiness, TicketBusiness>();
builder.Services.AddScoped<IGenericRepository<Ticket>, GenericRepository<Ticket>>();
builder.Services.AddScoped<IGenericBusiness<Ticket>, GenericBusiness<Ticket>>();
builder.Services.AddScoped<TicketBusiness>();

//Clases principales 
builder.Services.AddScoped<ValidarNuevosRegistrosBusiness>();
builder.Services.AddScoped<GeneradorImagenBusiness>();


builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDataProtection();
builder.Services.AddProblemDetails();
var app = builder.Build();
app.UseExceptionHandler();
app.UseStatusCodePages();

// Habilitar compresión para respuestas JSON
app.UseSwagger();
app.UseSwaggerUI(
c =>
{
    // Para que los modelos no se muestren expandidos por defecto
    //c.DefaultModelsExpandDepth(-1);
    // Aqu  se agregan los grupos de controladores por cada esquema
    c.SwaggerEndpoint("/swagger/ValidadorNuevosRegistros/swagger.json", "Validador de nuevos registros");
    c.SwaggerEndpoint("/swagger/Despachos/swagger.json", "Despachos");
}
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "api/{namespace}/{controller=Home}/{action=Index}/{id?}");

app.Run();
