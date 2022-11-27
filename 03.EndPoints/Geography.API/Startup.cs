using Geography.ApplicationServices.Provinces;
using Geography.Domain.Provinces.Contracts;
using Geography.SqlServer;
using Geography.SqlServer.Provinces;
using Microsoft.EntityFrameworkCore;

namespace Geography.API;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddScoped<AddProvinceHandler, AddProvinceCommandHandler>();
        services.AddScoped<ProvinceRepository, EFProvinceRepository>();
        services.AddDbContext<EFDataContext>(option =>
        {
            option.UseSqlServer(
                "Server=.;Database=DomainRichSampleDB;user id=sa;password=123@qwe123;TrustServerCertificate=true");
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapSwagger();
        });
    }
}