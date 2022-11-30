using Microsoft.EntityFrameworkCore;
using SCA.AssetRegisterApi.Context;
using SCA.AssetRegisterApi.Repositories;
using SCA.AssetRegisterApi.Repositories.Contracts;
using SCA.AssetRegisterApi.Services;
using SCA.AssetRegisterApi.Services.Contracts;
using System.Text.Json.Serialization;

namespace SCA.AssetRegisterApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        //services.AddControllers();
        services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        services.AddSwaggerGen();
        
        services.AddDbContext<AssetContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionSQL")));

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
        services.AddScoped<IAssetTypeService, AssetTypeService>();
        services.AddScoped<IAssetRepository, AssetRepository>();
        services.AddScoped<IAssetService, AssetService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            string basePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";
            options.SwaggerEndpoint($"{basePath}/swagger/v1/swagger.json", "v1");
            options.OAuthAppName("SCA.AssetRegisterAPI");
            options.OAuthScopeSeparator(" ");
            options.OAuthUsePkce();
        });

        app.UseHttpsRedirection();
               

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();

            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Arquitetura de Software Distribuído - TCC ");
            });
        });
    }
}