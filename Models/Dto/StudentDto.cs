namespace DormAPI.Models.Dto
{
    public record StudentDto : PersonDto
    {
        public string IndexNumber { get; init; }
    }
}
