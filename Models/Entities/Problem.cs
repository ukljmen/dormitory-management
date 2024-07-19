using DormAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Problem
    /// </summary>
    public class Problem : Entity
    {
        /// <summary>
        /// Problem's state
        /// </summary>
        public ProblemStatus ProblemState { get; set; } = ProblemStatus.Sent;

        /// <summary>
        /// Id of the student reporting the problem
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Short description of a problem
        /// </summary>
        [MaxLength(256)]
        public string Description { get; set; } = default!;

        /// <summary>
        /// Id of the item that the problem concerns
        /// </summary>
        public int? ItemId { get; set; } = default!;

        /// <summary>
        /// Id of the conserver assigned to the problem
        /// </summary>
        public int? ConservatorId { get; set; }

        /// <summary>
        /// Reference to the conservator assigned to the problem
        /// </summary>
        public Conservator? Conservator { get; set; } = default!;

        /// <summary>
        /// Reference to item, if null the problem concerns the reporting tenant's room
        /// </summary>
        public Item? Item { get; set; } = default!;

        /// <summary>
        /// Date and time the problem was reported
        /// </summary>
        public DateTime IssuedTs { get; set; } = DateTime.UtcNow;
    }
}
