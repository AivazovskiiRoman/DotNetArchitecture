using System;
using Solution.Model.Enums;

namespace Solution.Model.Models
{
    public class UserLogModel
    {
        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public LogType LogType { get; set; }

        public virtual UserModel User { get; set; }

        public long UserId { get; set; }

        public long UserLogId { get; set; }
    }
}
