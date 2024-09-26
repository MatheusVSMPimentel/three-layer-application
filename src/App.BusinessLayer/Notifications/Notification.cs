namespace App.BusinessLayer.Notifications
{
    public record Notification(string message)
    {
        public string Message { get; } = message;
    }
}
