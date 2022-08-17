using Microsoft.EntityFrameworkCore;
using publication.Repository;
using publication.Repository.Implementation;
using publication.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injeção de dependencia
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IPublicationRepository , PublicationRepository>();

string mySqlConnection = builder.Configuration.GetConnectionString("connectDeafultMysql");
builder.Services.AddDbContext<PublicationContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

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
