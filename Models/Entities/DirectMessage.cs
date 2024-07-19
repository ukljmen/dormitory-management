namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Direct message, sent by a manager to specific students
    /// </summary>
    public class DirectMessage : Message
    {
        /// <summary>
        /// Author's id
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// Reference to author
        /// </summary>
        public Manager Manager { get; set; } = default!;

        public List<DirectMessageStudent> DirectMessageStudents { get; set; } = default!;
    }
}
