using DormAPI.Models.Enums;

namespace DormAPI.Models.Dto
{
    public record ProblemDto : DtoId
    {
        public string Description { get; init; }
        public ProblemStatus Status { get; init; }
        public DtoNameId? Item { get; init; }
        public DtoNameId? Conservator { get; init; }
        public DateTime IssuedTs { get; init; }
    }
}
