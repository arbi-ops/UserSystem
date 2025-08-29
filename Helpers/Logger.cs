using System;
using UserSystem.Models;

namespace UserSystem.Helpers
{
    public static class Logger
    {
        public static void Log(string action, string userName = "System")
        {
            using (var db = new ApplicationDbContext())
            {
                db.ActivityLogs.Add(new ActivityLog
                {
                    Action = action,
                    UserId = userName,
                    TimestampUtc = DateTime.Now
                });
                db.SaveChanges();
            }
        }
    }
}
