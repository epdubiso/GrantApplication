using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2017MVC.Models;

namespace CommunityAssist2017MVC.Controllers
{
    public class GrantApplicationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
       
        // GET: GrantApplication
        public ActionResult Index()
        {
            if (Session["personkey"] ==null)
            {
                Message m = new Message();
                m.MessageText = "Must be logged in to apply";
                return RedirectToAction("Result", m);
            }
            ViewBag.GrantTypeKey = new SelectList(db.GrantTypes, "GrantTypeKey, GrantTypeName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = " GrantApplicationKey, PersonKey, GrantApplicationDate, GrantTypeKey, " +
            "GrantAplicationRequestAmount, GrantApplicationReason, GrantApplicationStutesKey,GrantApplicationAllocationAmount ")] GrantApplication g)
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
           
            g.GrantAppicationDate = DateTime.Now;
            g.PersonKey = (int)Session["personkey"];
            g.GrantApplicationStatusKey = 1;
            db.GrantApplications.Add(g);
            db.SaveChanges();
              


                Message m = new Message();
                m.MessageText = "Thank you for applying for grant";
                return View("Result", m);
            

        }
        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}