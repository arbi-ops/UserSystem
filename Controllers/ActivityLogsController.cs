using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UserSystem.Models;

namespace UserSystem.Controllers
{
    public class ActivityLogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var logs = db.ActivityLogs
                .OrderByDescending(l => l.TimestampUtc)
                .Take(100) 
                .ToList();
            return View(logs);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var log = db.ActivityLogs.Find(id);
            if (log == null)
                return HttpNotFound();

            return View(log);
        }
    }
}
