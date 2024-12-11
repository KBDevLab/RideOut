

namespace Rideout.Application.DTOs
{

    public class ReviewsDto
    {    
        public int Reviewid { get; set; }

        public int Rideoutid { get; set; }

        public int Userid { get; set; }

        public int? Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime? Reviewedat { get; set; }
    }

}