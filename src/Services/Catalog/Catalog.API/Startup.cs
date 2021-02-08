using Catalog.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Catalog.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITripRepository>(s => new TripRepository(Configuration.GetConnectionString("Catalog")));
            services.AddTransient<IAccomodationRepository>(s => new AccomodationRepository(Configuration.GetConnectionString("Catalog")));
            services.AddTransient<ICommentRepository>(s => new CommentRepository(Configuration.GetConnectionString("Catalog")));
            services.AddTransient<IActivityRepository>(s => new ActivityRepository(Configuration.GetConnectionString("Catalog")));
            services.AddTransient<ICityRepository>(s => new CityRepository(Configuration.GetConnectionString("Catalog")));
            services.AddControllers();
            services.AddCors(options => options.AddDefaultPolicy(
                builder => builder.WithOrigins("http://localhost:3000")));


            services.AddSwaggerGen(
           c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo
               {
                   Title = "NewLifeTrip",
                   Version = "v1"
               });

           });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NewLifeTrip v1");
                });


            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
