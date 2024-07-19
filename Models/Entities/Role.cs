using Microsoft.AspNetCore.Identity;

namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Class representing user types
    /// </summary>
    public class Role : IdentityRole<int>
    {
        /// <summary>
        /// Constructor used by the model creating method to populate the roles table when initializing new database
        /// </summary>
        /// <param name="name">Role's name</param>
        public Role(string name)
            : base(name)
        {

        }
    }
}
