using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment4.Controllers
{
    public class CustomersController : Controller
    {
        private readonly DatabaseContext context;
        public CustomersController(DatabaseContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var Query= from item in context.Cust
                       select item;
            var Data = Query.ToList();
            return View(Data);
        }
        private void CreateDropDownData()
        {
            var Cities = new List<string> { "Pune", "Satara", "Mumbai" };
            var CitiesList = new SelectList(Cities);
            ViewBag.CitiesData = CitiesList;
        }
        public IActionResult Create()
        {
            CreateDropDownData();
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Customer_Model C1)
        {
            if(!ModelState.IsValid)
            {
                return View(C1);
            }
            context.Cust.Add(C1);
            int Rows = context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var Customer = context.Cust.Find(id);
            if(Customer==null)
            {
                return NotFound();
            }
            return View(Customer);
        }

        public IActionResult Edit(int id)
        {
            var Customer = context.Cust.Find(id);
            if(Customer==null)
            {
                return NotFound();
            }

            return View(Customer);
        }
        [HttpPost]
        public IActionResult Edit(int id, Customer_Model c1)
        {
            if (!ModelState.IsValid)
            {
                return View(c1);
            }
            var Customer_Obj = context.Cust.Find(c1.Id);
            Customer_Obj.CustomerName = c1.CustomerName;
            Customer_Obj.CustomerCity = c1.CustomerCity;
            Customer_Obj.CustomerEmail = c1.CustomerEmail;
            Customer_Obj.CustomerPhoneNo = c1.CustomerPhoneNo;

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var Cust1 = context.Cust.Find(id);
            if(Cust1==null)
            {
                return NotFound();
            }

            return View(Cust1);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete_Confirmed(int id)
        {
            var Cust1 = context.Cust.Find(id);
            context.Cust.Remove(Cust1);
            context.SaveChanges();
               return RedirectToAction("Index");
        }

        public IActionResult Search(string cityname)
        {
            var Query = from obj in context.Cust
                        where obj.CustomerCity.Contains(cityname)
                        select obj;
            var Data = Query.ToList();
            return View("Index", Data);
        }
    }
}
