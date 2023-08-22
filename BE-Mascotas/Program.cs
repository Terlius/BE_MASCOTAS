using BE_Mascotas.Models;
using BE_Mascotas.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebApp",builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});



// Add contex
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Conexion");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

//AutoMaper
builder.Services.AddAutoMapper(typeof(Program));

//Add Repository
builder.Services.AddScoped<IMascotaRepository, MascotaRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowWebApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
