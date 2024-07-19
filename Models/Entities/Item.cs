using System.ComponentModel.DataAnnotations;

namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Class representing the room's item entity
    /// </summary>
    public class Item : Entity
    {
        /// <summary>
        /// Item's name
        /// </summary>
        [MaxLength(256)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Id of the item's room
        /// </summary>
        public int RoomId { get; set; } = default!;

        /// <summary>
        /// List of problems assigned to the item
        /// </summary>
        public List<Problem> Problems { get; set; } = default!;
    }
}
