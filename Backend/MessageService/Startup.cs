using MessageService.DataBase;
using MessageService.DataBase.Interfaces;
using MessageService.Notifications;
using MessageService.Notifications.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace MessageService
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
            services.AddDbContext<InMemoryContext>(options => options.UseInMemoryDatabase("MessagesDB"));
            services.AddTransient<IStorageService, StorageServicecs>();
            services.AddTransient<INotificationProxy, NotificationProxy>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddMvc();
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
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Message Service v1.0"));
        }
    }
}
