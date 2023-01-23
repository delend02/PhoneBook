using System;
using ToastNotifications;
using ToastNotifications.Core;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace PhoneBook.WPF.Service
{
    public class Notification
    {
        private static Notifier _notifier  = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: System.Windows.Application.Current.MainWindow,
                corner: Corner.BottomRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(6),
                maximumNotificationCount: MaximumNotificationCount.FromCount(6));

            cfg.Dispatcher = System.Windows.Application.Current.Dispatcher;

            cfg.DisplayOptions.TopMost = false;
            cfg.DisplayOptions.Width = 250;
        });
      
        public static void OnUnloaded()
        {
            _notifier.Dispose();
        }

        public static void ShowInformation(string message) => _notifier.ShowInformation(message);

        public static void ShowInformation(string message, MessageOptions opts) => _notifier.ShowInformation(message, opts);

        public static void ShowSuccess(string message) => _notifier.ShowSuccess(message);

        public static void ShowSuccess(string message, MessageOptions opts) => _notifier.ShowSuccess(message, opts);

        public static void ShowWarning(string message) => _notifier.ShowWarning(message);

        public static void ShowWarning(string message, MessageOptions opts) => _notifier.ShowWarning(message, opts);

        public static void ShowError(string message) => _notifier.ShowError(message);

        public static void ShowError(string message, MessageOptions opts) => _notifier.ShowError(message, opts);
    }
}
