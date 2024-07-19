namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Conservator
    /// </summary>
    public class Conservator : Person
    {
        /// <summary>
        /// List of problems assigned to the conservator
        /// </summary>
        public List<Problem> Problems { get; set; } = default!;
    }
}
