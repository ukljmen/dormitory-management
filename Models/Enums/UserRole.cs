namespace DormAPI.Models.Enums
{
    /// <summary>
    /// 1 - Admin
    /// 2 - Manager
    /// 3 - Conservator
    /// 4 - Student
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Admin
        /// </summary>
        Admin = 1,

        /// <summary>
        /// Manager
        /// </summary>
        Manager,

        /// <summary>
        /// Conservator
        /// </summary>
        Conservator,

        /// <summary>
        /// Student
        /// </summary>
        Student
    }
}
