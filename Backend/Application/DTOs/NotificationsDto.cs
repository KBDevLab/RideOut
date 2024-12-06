namespace Rideout.Application.DTOs
{
    public class NotificationsDto
    {
    public int Notificationid { get; set; }

    public int Userid { get; set; }

    public string Content { get; set; } = null!;

    public bool? Isread { get; set; }

    public DateTime? Sentat { get; set; }
    }
}