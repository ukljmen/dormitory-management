namespace DormAPI.Models.Dto
{
    public record RoomDto : RoomSimpleDto
    {
        public IEnumerable<ItemDto> Items { get; init; }
        public IEnumerable<ProblemDto> Problems { get; init; }
    }
}
