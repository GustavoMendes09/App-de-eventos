using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProEventos.CrossCutting.Mappings;
using ProEventos.Domain.Business;
using ProEventos.Domain.Interfaces.Business;
using ProEventos.Domain.Interfaces.Data;
using ProEventos.InfraStructure.Data;
using ProEventos.InfraStructure.Data.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API
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
            services.AddDbContext<DataContext>(
                  context => context.UseSqlServer(Configuration.GetConnectionString("Default"))
                );
            services.AddCors();
            services.AddControllers()
                .AddNewtonsoftJson(x => 
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            #region configuração AutoMapper

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProEventosProfile());
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            #endregion

            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IEventosRepository, EventosRepository>();
            services.AddScoped<ILoteService, LoteService>();
            services.AddScoped<ILoteRepository, LoteRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProEventos.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin()
                                );

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path
                .Combine(Directory.GetCurrentDirectory(), "Resources")
                ),
                RequestPath = new PathString("/Resources")
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
