using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdityaHomes.Models;
using System.Data.Entity;
namespace AdityaHomes.Controllers
{
    public class EnquiryController : Controller
    {
        //
        // GET: /Enquiry/
        AHdbContext db = new AHdbContext();

        public ActionResult Enquiry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEnquiry(EnquiryModel enquiry)
        {
            if (ModelState.IsValid)
            {
                enquiry.enquiryDate = DateTime.Now;
                enquiry.replyDate = DateTime.Now;
                enquiry.status = "Received";
                db.Entry(enquiry).State = System.Data.EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("EnquiryList");
            }
            else
                ModelState.AddModelError("QuerySubmissionError", "Query submitted unsuccessful.");
            return RedirectToAction("Enquiry");
        }
        [HttpGet]
        public ActionResult Reply(int id = 0)
        {
            EnquiryModel enquiry = db.Enquiries.Find(id);
            if (enquiry == null)
            {
                return HttpNotFound();
            }
            return View(enquiry);
        }

        [HttpPost]
        public ActionResult Reply(EnquiryModel enquiry)
        {
            
                enquiry.replyDate = DateTime.Now;
                enquiry.status = "Replied";
                db.Entry(enquiry).State = System.Data.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("EnquiryList");
         
        }
        [HttpGet]
        public ActionResult EnquiryList()
        {
            if (ModelState.IsValid)
            {
                List<EnquiryModel> enquiries = db.Enquiries.ToList();
                return View(enquiries);
            }
            else
                ModelState.AddModelError("QuerySubmissionError", "Query submitted unsuccessful.");
                return RedirectToAction("Enquiry");
        }
        
        
    }
}
