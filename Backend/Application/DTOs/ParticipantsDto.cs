namespace Rideout.Application.DTOs
{
    public class ParticipantsDto
    {
        public int ParticipantID { get; set; }
        public int RideOutID { get; set; }
        public int UserID { get; set; }
        public string Status { get; set; }
        public DateTime? JoinedAt { get; set; }
    }
}
