using MediatR;
using Microsoft.Extensions.DependencyInjection;
using User.CrossCutting.Bus;
using User.Domain.Core.Bus;
using User.Domain.Core.Notifications;
using Users.Domain.CommandHandlers;
using Users.Domain.Commands.User;
using Users.Domain.EventHandlers;
using Users.Domain.Events;

namespace Users.CrossCutting.IoC
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