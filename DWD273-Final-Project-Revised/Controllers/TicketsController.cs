using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DWD273_Final_Project_Revised.Models;
using System.Data.Entity.Migrations;

namespace DWD273_Final_Project_Revised.Controllers
{
    public class TicketsController : Controller
    {
        private TicketContext db = new TicketContext();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Topic);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.TopicID = new SelectList(db.Topics, "ID", "TopicDesc");
            //Auto-Fill First and Last Name (Do this in comments)
            var dbContext = new ApplicationDbContext();
            ApplicationUser appUser = dbContext.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

            Ticket viewModel = new Ticket();
            viewModel.firstName = appUser.FirstName;
            viewModel.lastName = appUser.LastName;
            return View(viewModel);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,message,resolved,TopicID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {

                ticket.submitTime = DateTime.Now;
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TopicID = new SelectList(db.Topics, "ID", "TopicDesc", ticket.TopicID);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicID = new SelectList(db.Topics, "ID", "TopicDesc", ticket.TopicID);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,message,resolved,submitTime,TopicID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TopicID = new SelectList(db.Topics, "ID", "TopicDesc", ticket.TopicID);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
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

        [HttpPost]
        public ActionResult AddComment([Bind(Include = "firstName,lastName,message,TicketID,time")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                comment.time = DateTime.Now.ToShortDateString();
                db.SaveChanges();
                return RedirectToAction("Details/" + comment.TicketID);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
