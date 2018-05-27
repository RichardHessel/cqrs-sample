using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Users.CrossCutting.Bus;
using Users.Domain.Core.Bus;
using Users.Domain.Core.Notifications;
using Users.Domain.CommandHandlers;
using Users.Domain.Commands.User;
using Users.Domain.EventHandlers;
using Users.Domain.Events;
using Users.Domain.Interfaces;
using Users.Domain.Interfaces.Repositories;
using Users.Infra.Persistence.Repositories;
using Users.Domain.QuerySide.Queries.Users;
using Users.Domain.QuerySide.QueryHandlers.Users;
using Users.Domain.Entities;

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
            services.AddScoped<IRequestHandler<CreateUserCommand>, UserCommandHandler>();

            // queries
            services.AddScoped<IRequestHandler<GetUserByMailQuery, User>, UserQueryHandler>();


            // infra 
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}