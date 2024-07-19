namespace DormAPI.Models.Dto
{
    public record AnnouncementDto : MessageDto
    {
        public DtoNameId Author { get; init; }
    }
}
