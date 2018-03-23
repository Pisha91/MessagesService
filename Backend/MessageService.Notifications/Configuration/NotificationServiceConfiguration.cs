using MessageService.Notifications.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Notifications.Configuration
{
    public static class NotificationServiceConfiguration
    {
        public static void AddNotificationProxy(this IServiceCollection services)
        {
            services.AddTransient<INotificationProxy, NotificationProxy>();
        }
    }
}
