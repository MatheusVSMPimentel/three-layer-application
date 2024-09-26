using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessLayer.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications = [];
        
        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        private void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }
        public void Handle(string message)
        {
            Handle(new Notification(message));
        }

        public bool HasNotification()
        {
            return _notifications.Count > 0 ;
        }
    }
}
