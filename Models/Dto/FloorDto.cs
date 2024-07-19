namespace DormAPI.Models.Dto
{
    public record FloorDto : DtoId
    {
        public int FloorNumber { get; init; }

        public IEnumerable<RoomSimpleDto> Rooms { get; init; }
    }
}
