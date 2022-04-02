using System.Collections.Generic;

namespace OneSignal.Models
{
    public class CreateNotificationModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> PlayerIds { get; set; }
    }
}
