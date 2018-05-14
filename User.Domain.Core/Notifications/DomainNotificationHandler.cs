using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace User.Domain.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;
        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public async Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
        }
        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }
        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }
        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }

      
    }
}