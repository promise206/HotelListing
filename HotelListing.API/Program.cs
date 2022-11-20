using HotelListing.API.Data;
using HotelListing.API.IRepository;
using HotelListing.API.Repository;
using HotelListing.API.Utility;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers(setupAction =>
{
    setupAction.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson(v => v.SerializerSettings.ReferenceLoopHandling = Newtonsoft
    .Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("C:\\Users\\solan\\Desktop\\Log", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Services.AddCors();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString
    ("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(HotelListingProfile));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
await DbInitializer.Seed(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
