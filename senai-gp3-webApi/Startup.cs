using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Interfaces;
using senai_gp3_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai_gp3_webApi
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

            services.AddControllers();

            services.AddControllers()
               .AddNewtonsoftJson(options =>
               {
                   options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                   options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
               });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                builder =>
                                {
                                    builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SenaiRHG1.webAPI", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.EnableAnnotations();
            });

            services.AddDbContext<senaiRhContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("AzureDBConnetionString"))
);

            services
                .AddAuthentication(option =>
                {
                    option.DefaultAuthenticateScheme = "JwtBearer";
                    option.DefaultChallengeScheme = "JwtBearer";
                }
                )

                .AddJwtBearer("JwtBearer", options =>
                options.TokenValidationParameters = new TokenValidationParameters()
                {

                    // será validado emissor do token
                    ValidateIssuer = true,

                    //será validade endereço do token
                    ValidateAudience = true,

                    //será vailidado tempo do token
                    ValidateLifetime = true,

                    //definição da chave de segurança
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senairh-autenticacao-token")),

                    //define o tempo de expiração
                    ClockSkew = TimeSpan.FromHours(1),

                    ValidIssuer = "SenaiRH_G1.WebApi",

                    ValidAudience = "SenaiRH_G1.WebApi"
                }
                );



            services.AddTransient<DbContext, senaiRhContext>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IDecisaoRepository, DecisaoRepository>();
            services.AddTransient<IFeedbackRepository, FeedBackRepository>();
            services.AddTransient<ICargoRepository, CargoRepository>();
            services.AddTransient<IUnidadesenaiRepository, UnidadesenaiRepository>();
            services.AddTransient<IIdTipoUsuarioRepository, IdTipoUsuarioRepository>();
            services.AddTransient<IHistoricoRepository, HistoricoRepository>();
            services.AddTransient<IAvaliacaoUsuarioRepository, AvaliacaoUsuarioRepository>();
            services.AddTransient<IGrupoRepository, GrupoRepository>();
            services.AddTransient<ILotacaoRepository, LotacaoRepository>();
            services.AddTransient<IHistoricoUnidadeRepository, HistoricoUnidadeRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SenaiRH_GP1.WebAPI");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
