namespace Rideout.Application.DTOs
{
    public class UsersDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string ProfilePicture { get; set; }
        public string Bio { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
