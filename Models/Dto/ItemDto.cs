using DormAPI.Models.Enums;

namespace DormAPI.Models.Dto
{
    public record ItemDto : DtoNameId
    {
        public ProblemStatus Status { get; set; } = ProblemStatus.Resolved;
    }
}
