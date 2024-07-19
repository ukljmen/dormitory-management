namespace DormAPI.Models.Enums
{
    /// <summary>
    /// 0 - resolved
    /// 1 - sent
    /// 2 - assigned
    /// 3 - in progress
    /// 4 - fixed
    /// </summary>
    public enum ProblemStatus
    {
        /// <summary>
        /// The problem has been sucsessfuly handled
        /// </summary>
        Resolved = 0,

        /// <summary>
        /// The problem has been sent by a tenant
        /// </summary>
        Sent,

        /// <summary>
        /// The problem has been assigned to a conserver
        /// </summary>
        Assigned,

        /// <summary>
        /// The problem has been accepted by a conservator
        /// </summary>
        InProgress,

        /// <summary>
        /// The problem has been fixed and now awaits to be set as resolved by a manager
        /// </summary>
        Fixed
    }
}
