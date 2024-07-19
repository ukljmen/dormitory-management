using System.ComponentModel.DataAnnotations;

namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Abstract class derived by classes representing specific types of users
    /// </summary>
    public abstract class Person : Entity
    {
        /// <summary>
        /// Person's first name
        /// </summary>
        [MaxLength(100)]
        public string FirstName { get; set; } = default!;

        /// <summary>
        /// Person's last name
        /// </summary>
        [MaxLength(100)]
        public string LastName { get; set; } = default!;

        /// <summary>
        /// Person's full name getter
        /// </summary>
        public string Name { get => $"{FirstName} {LastName}"; }

        /// <summary>
        /// Person's account ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Reference to person's account entity
        /// </summary>
        public User User { get; set; } = default!;
    }
}
