using exorecapapi.Entities;
using exorecapapi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

string cnstr = builder.Configuration.GetConnectionString("Dev");
builder.Services.AddScoped<IRepository<JeuxPOCO, int>, JeuxRepository>(s => new JeuxRepository(cnstr));
builder.Services.AddScoped<IRepository<GenrePOCO, int>, GenreRepository>(s => new GenreRepository(cnstr));