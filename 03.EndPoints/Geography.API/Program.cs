using Geography.ApplicationServices.Provinces;
using Geography.Domain.Provinces.Contracts;
using Geography.SqlServer;
using Geography.SqlServer.Provinces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AddProvinceHandler, AddProvinceCommandHandler>();
builder.Services.AddScoped<ProvinceRepository, EFProvinceRepository>();
builder.Services.AddScoped<ProvinceQueryRepository, EFProvinceQueryRepository>();
builder.Services.AddDbContext<EFDataContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("dbConnectionString"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();