
namespace Rideout.Application.DTOs
{
public class RideoutDto
{
    public int RideOutID { get; set; }
    public int HostUserID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime DateTime { get; set; }
    public int MaxParticipants { get; set; }
    public DateTime CreatedAt { get; set; }
 
    public DateTime UpdatedAt { get; set; }
}
}