

namespace Rideout.Application.DTOs
{

    public class ReviewsDto
    {
    public int Rideoutid { get; set; }

    public int Hostuserid { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Location { get; set; } = null!;

    public DateTime Datetime { get; set; }

    public int? Maxparticipants { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }
    }

}