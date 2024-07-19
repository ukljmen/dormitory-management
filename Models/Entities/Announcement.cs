namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Announcement, sent by a manager to the dorm's public 
    /// </summary>
    public class Announcement : Message
    {
        /// <summary>
        /// Author's id
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// Reference to author
        /// </summary>
        public Manager Manager { get; set; } = default!;
    }
}
