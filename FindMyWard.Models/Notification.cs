
namespace FindMyWard.Models;

public class Notification
{
    public int Id { get; set; }

    public string Subject { get; set; }

    public string Message { get; set; }

    public int EventId { get; set; }

    public Event Event { get; set; }
}
