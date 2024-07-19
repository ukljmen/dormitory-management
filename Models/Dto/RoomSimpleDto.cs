namespace DormAPI.Models.Dto
{
    public record RoomSimpleDto : DtoId
    {
        public int RoomNumber { get; init; }
        public IEnumerable<StudentDto> Students { get; init; }
    }
}
