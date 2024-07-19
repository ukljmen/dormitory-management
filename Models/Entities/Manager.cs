namespace DormAPI.Models.Entities
{
    /// <summary>
    /// Manager
    /// </summary>
    public class Manager : Person
    {
        public List<DirectMessage> DirectMessagesSent { get; set; } = default!;
        public List<Announcement> AnnouncementsSent { get; set; } = default!;
    }
}
