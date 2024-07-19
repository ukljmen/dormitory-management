namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Join table for associating students with direct messages
    /// </summary>
    public class DirectMessageStudent
    {
        /// <summary>
        /// Student id
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Message id
        /// </summary>
        public int DirectMessageId { get; set; }

        /// <summary>
        /// Flag that is set when the student opens the message
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// Reference to the message
        /// </summary>
        public DirectMessage DirectMessage { get; set; } = default!;

        public Student Student { get; set; } = default!;
    }
}
