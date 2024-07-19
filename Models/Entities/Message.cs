using System.ComponentModel.DataAnnotations;

namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Base class for message type entities (e.g. direct messages or announcements)
    /// </summary>
    public abstract class Message : Entity
    {
        /// <summary>
        /// Title
        /// </summary>
        [MaxLength(256)]
        public string Title { get; set; } = default!;

        /// <summary>
        /// Content
        /// </summary>
        [MaxLength(1024)]
        public string Content { get; set; } = default!;

        /// <summary>
        /// Date and time the message was sent
        /// </summary>
        public DateTime AddedTS { get; set; } = DateTime.Now;
    }
}
