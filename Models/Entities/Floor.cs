namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Class representing dorm's floors
    /// </summary>
    public class Floor : Entity
    {
        /// <summary>
        /// Floor number
        /// </summary>
        public int FloorNumber { get; set; }

        /// <summary>
        /// Reference to the collection of rooms on a given floor
        /// </summary>
        public List<Room> Rooms { get; set; } = default!;
    }
}
