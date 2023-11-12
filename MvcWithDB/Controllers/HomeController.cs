using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MvcWithDB.Controllers
{
    public class HomeController : Controller
    {
        StudentEntitiesContext _context = new StudentEntitiesContext();
        public ActionResult Index()
        {
            var listofDate=_context.Students.ToList();
            
            return View(listofDate);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student model)
        {
            _context.Students.Add(model);   
            _context.SaveChanges();
            ViewBag.Messege = "Date insert Success";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id) 
        { 
            var data=_context.Students.Where(x=>x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var data = _context.Students.Where(x => x.StudentId == student.StudentId).FirstOrDefault();
            if (data != null)
            {
                data.StudentCity = student.StudentCity;
                data.StudentName = student.StudentName;
                data.StudentFees = student.StudentFees;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        
        }
      
        public ActionResult Detail(int id)
        { 
            var data=_context.Students.Where(x=>x.StudentId==id).FirstOrDefault();  
            return View(data);
        
        }
        
        public ActionResult Delete(int id)
        {
            var data=_context.Students.Where(x=>x.StudentId==id).FirstOrDefault();
            _context.Students.Remove(data);
            _context.SaveChanges();
            ViewBag.Messege = "Succesfully deleted";
            return RedirectToAction("Index");   
        }
        
    }
}