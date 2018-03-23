using MessageService.Notifications;
using MessageService.Notifications.Configuration;
using MessageService.Notifications.Interfaces;
using MessageService.Services;
using MessageService.Services.Interfaces;
using MessageService.Storage.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace MessageService
{
    public class Startup
    {
        private const string CorsPolicy = "AllowAllMethods";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInMemoryMessageStorage();
            services.AddNotificationProxy();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddMvc(options => options.OutputFormatters.RemoveType<StringOutputFormatter>());
            services.AddCors(options => options.AddPolicy(CorsPolicy, builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1.0", new Info { Title = "Message Service", Version = "v1.0" });
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors(CorsPolicy);
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Message Service v1.0"));
        }
    }
}
