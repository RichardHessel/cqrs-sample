using Microsoft.Extensions.DependencyInjection;
using User.Domain.Core.Bus;
using User.CrossCutting.Bus;

namespace User.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<UserRegisteredEvent>, UserEventHandler>();

            // commands
            services.AddScoped<INotificationHandler<CreateUserCommand>, UserCommandHandler>();



        }
    }
}