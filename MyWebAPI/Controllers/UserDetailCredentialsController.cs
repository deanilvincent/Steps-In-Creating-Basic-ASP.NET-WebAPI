using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    public class UserDetailCredentialsController : Controller
    {
        private MySampDBContext db = new MySampDBContext();

        // GET: UserDetailCredentials
        public async Task<ActionResult> Index()
        {
            return View(await db.UserDetailCredentials.ToListAsync());
        }

        // GET: UserDetailCredentials/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetailCredentials userDetailCredentials = await db.UserDetailCredentials.FindAsync(id);
            if (userDetailCredentials == null)
            {
                return HttpNotFound();
            }
            return View(userDetailCredentials);
        }

        // GET: UserDetailCredentials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDetailCredentials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Username,Password,Name")] UserDetailCredentials userDetailCredentials)
        {
            if (ModelState.IsValid)
            {
                db.UserDetailCredentials.Add(userDetailCredentials);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userDetailCredentials);
        }

        // GET: UserDetailCredentials/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetailCredentials userDetailCredentials = await db.UserDetailCredentials.FindAsync(id);
            if (userDetailCredentials == null)
            {
                return HttpNotFound();
            }
            return View(userDetailCredentials);
        }

        // POST: UserDetailCredentials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Username,Password,Name")] UserDetailCredentials userDetailCredentials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetailCredentials).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userDetailCredentials);
        }

        // GET: UserDetailCredentials/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetailCredentials userDetailCredentials = await db.UserDetailCredentials.FindAsync(id);
            if (userDetailCredentials == null)
            {
                return HttpNotFound();
            }
            return View(userDetailCredentials);
        }

        // POST: UserDetailCredentials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserDetailCredentials userDetailCredentials = await db.UserDetailCredentials.FindAsync(id);
            db.UserDetailCredentials.Remove(userDetailCredentials);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
