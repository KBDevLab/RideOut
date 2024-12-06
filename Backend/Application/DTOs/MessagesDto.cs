namespace Rideout.Application.DTOs
{
    public class MessagesDto
    {
    public int Messageid { get; set; }

    public int Rideoutid { get; set; }

    public int Senderuserid { get; set; }

    public string Messagetext { get; set; } = null!;

    public DateTime? Sentat { get; set; }
    }
}
