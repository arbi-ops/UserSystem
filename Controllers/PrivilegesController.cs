using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using UserSystem.Models;
using System.Linq;

public class PrivilegesController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Privileges
    public ActionResult Index()
    {
        var privileges = db.Privileges.Include(p => p.Group).ToList();
        return View(privileges);
    }

    // GET: Privileges/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        var privilege = db.Privileges.Include(p => p.Group).FirstOrDefault(p => p.Id == id);
        if (privilege == null)
            return HttpNotFound();

        return View(privilege);
    }

    // GET: Privileges/Create
    public ActionResult Create()
    {
        ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
        return View();
    }

    // POST: Privileges/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Name,GroupId")] Privilege privilege)
    {
        if (ModelState.IsValid)
        {
            db.Privileges.Add(privilege);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", privilege.GroupId);
        return View(privilege);
    }

    // GET: Privileges/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Privilege privilege = db.Privileges.Find(id);
        if (privilege == null)
            return HttpNotFound();

        ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", privilege.GroupId);
        return View(privilege);
    }

    // POST: Privileges/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Name,GroupId")] Privilege privilege)
    {
        if (ModelState.IsValid)
        {
            db.Entry(privilege).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", privilege.GroupId);
        return View(privilege);
    }

    // GET: Privileges/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Privilege privilege = db.Privileges.Find(id);
        if (privilege == null)
            return HttpNotFound();

        return View(privilege);
    }

    // POST: Privileges/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Privilege privilege = db.Privileges.Find(id);
        db.Privileges.Remove(privilege);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            db.Dispose();
        base.Dispose(disposing);
    }
}
