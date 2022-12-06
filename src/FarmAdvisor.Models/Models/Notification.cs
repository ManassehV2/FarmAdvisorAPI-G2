using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmAdvisor.Models.Models
{
    public enum Status
    {
        Ok,
        Warning
    }
    public class Notification
    {

        public Guid NotificationId { get; set; }
        public Guid FarmId { get; set; }
        public Farm Farm { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public Status Status { get; set; }
        
    }
}
