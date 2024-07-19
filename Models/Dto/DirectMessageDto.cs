namespace DormAPI.Models.Dto
{
    public record DirectMessageDto : MessageDto
    {
        public DtoNameId Author { get; init; } = default!;
        public IEnumerable<DtoNameId> Receivers { get; init; } = default!;
    }
}
