using Rideout.Domain.Models;
using Rideout.Application.DTOs;

namespace Rideout.Application.Mappers
{
    public static class ParticipantMapper
    {
        public static ParticipantsDTO ToDTO(Participants participant)
        {
            return new ParticipantsDTO
            {
                ParticipantID = participant.Participantid,
                RideOutID = participant.Rideoutid,
                UserID = participant.Userid,
                Status = participant.Status,
                JoinedAt = participant.Joinedat
            };
        }

        public static Participants ToEntity(ParticipantsDTO participantDTO)
        {
            return new Participants
            {
                Participantid = participantDTO.ParticipantID,
                Rideoutid = participantDTO.RideOutID,
                Userid = participantDTO.UserID,
                Status = participantDTO.Status,
                Joinedat = participantDTO.JoinedAt
            };
        }
    }
}
