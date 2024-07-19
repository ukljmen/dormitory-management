using System.ComponentModel.DataAnnotations;

namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Base class for all types representing DB entities
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
