namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Room entity
    /// </summary>
    public class Room : Entity
    {
        /// <summary>
        /// Room number
        /// </summary>
        public int RoomNumber { get; set; } = default!;

        /// <summary>
        /// Floor number
        /// </summary>
        public int FloorId { get; set; } = default!;

        /// <summary>
        /// Items in the room
        /// </summary>
        public List<Item> Items { get; set; } = default!;

        /// <summary>
        /// References to room's tenants
        /// </summary>
        public List<Student> Students { get; set; } = default!;
    }
}
