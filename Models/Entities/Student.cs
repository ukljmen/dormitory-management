using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Student
    /// </summary>
    public class Student : Person
    {
        /// <summary>
        /// Student's index number
        /// </summary>
        [MaxLength(32)]
        public string IndexNumber { get; set; } = default!;

        /// <summary>
        /// Student's room Id
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Messages received by the student
        /// </summary>
        public List<DirectMessageStudent> DirectMessageStudents { get; set; } = default!;

        /// <summary>
        /// Problems reported by the student
        /// </summary>
        public List<Problem> Problems { get; set; } = default!;
    }
}
