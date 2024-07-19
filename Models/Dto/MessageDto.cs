namespace DormAPI.Models.Dto
{
    public record MessageDto : DtoId
    {
        public string Title { get; init; }

        public string Content { get; init; }

        public DateTime AddedTS { get; init; }
    }
}
