namespace RideOut.Application.DTOs
{
    public class ParticipantsDTO
    {
        public int ParticipantID { get; set; }
        public int RideOutID { get; set; }
        public int UserID { get; set; }
        public string Status { get; set; }
        public DateTime? JoinedAt { get; set; }
    }
}
