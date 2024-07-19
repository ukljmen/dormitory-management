namespace DormAPI.Models.Dto
{
    public record DtoNameId : DtoId
    {
        public string Name { get; init; }
    }
}
