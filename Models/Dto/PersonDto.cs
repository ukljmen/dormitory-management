namespace DormAPI.Models.Dto
{
    public record PersonDto : DtoId
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Name { get => $"{FirstName} {LastName}"; }
        public int UserId { get; init; }
    }
}
