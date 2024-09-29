using animepersonajesWebApi.Mappings;
using animepersonajesWebApi.Models;
using animepersonajesWebApi.Repositories;
using animepersonajesWebApi.Repositories.INT;
using animepersonajesWebApi.Services;
using animepersonajesWebApi.Services.INT;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//REPOS-SERVICES
builder.Services.AddScoped<IPersonajeRepo, PersonajeRepo>();
builder.Services.AddScoped<IAnimeRepo, AnimeRepo>();
builder.Services.AddScoped<IFinalService, FinalService>();

//FLUENT
builder.Services.AddFluentValidation((options) =>
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())
);

//AUTOMAPPER
builder.Services.AddAutoMapper(typeof(MappingProfile));

//DBCONTEXT
builder.Services.AddDbContext<PersonajesanimesContext>((context) =>
{
    context.UseSqlServer(builder.Configuration.GetConnectionString("animeDB"));
});

var app = builder.Build();

//CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

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
