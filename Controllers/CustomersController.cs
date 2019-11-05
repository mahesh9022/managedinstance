using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using managedsql;

namespace managedsql.Controllers
{
    public class CustomersController : Controller
    {
        private imsliteprodEntities1 db = new imsliteprodEntities1();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.City).Include(c => c.City1).Include(c => c.DeliveryMethod).Include(c => c.Person).Include(c => c.Person1).Include(c => c.Person2).Include(c => c.BuyingGroup).Include(c => c.CustomerCategory).Include(c => c.Customer1).Take(20);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryCityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.PostalCityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.DeliveryMethodID = new SelectList(db.DeliveryMethods, "DeliveryMethodID", "DeliveryMethodName");
            ViewBag.AlternateContactPersonID = new SelectList(db.People, "PersonID", "FullName");
            ViewBag.LastEditedBy = new SelectList(db.People, "PersonID", "FullName");
            ViewBag.PrimaryContactPersonID = new SelectList(db.People, "PersonID", "FullName");
            ViewBag.BuyingGroupID = new SelectList(db.BuyingGroups, "BuyingGroupID", "BuyingGroupName");
            ViewBag.CustomerCategoryID = new SelectList(db.CustomerCategories, "CustomerCategoryID", "CustomerCategoryName");
            ViewBag.BillToCustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CustomerName,BillToCustomerID,CustomerCategoryID,BuyingGroupID,PrimaryContactPersonID,AlternateContactPersonID,DeliveryMethodID,DeliveryCityID,PostalCityID,CreditLimit,AccountOpenedDate,StandardDiscountPercentage,IsStatementSent,IsOnCreditHold,PaymentDays,PhoneNumber,FaxNumber,DeliveryRun,RunPosition,WebsiteURL,DeliveryAddressLine1,DeliveryAddressLine2,DeliveryPostalCode,DeliveryLocation,PostalAddressLine1,PostalAddressLine2,PostalPostalCode,LastEditedBy,ValidFrom,ValidTo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryCityID = new SelectList(db.Cities, "CityID", "CityName", customer.DeliveryCityID);
            ViewBag.PostalCityID = new SelectList(db.Cities, "CityID", "CityName", customer.PostalCityID);
            ViewBag.DeliveryMethodID = new SelectList(db.DeliveryMethods, "DeliveryMethodID", "DeliveryMethodName", customer.DeliveryMethodID);
            ViewBag.AlternateContactPersonID = new SelectList(db.People, "PersonID", "FullName", customer.AlternateContactPersonID);
            ViewBag.LastEditedBy = new SelectList(db.People, "PersonID", "FullName", customer.LastEditedBy);
            ViewBag.PrimaryContactPersonID = new SelectList(db.People, "PersonID", "FullName", customer.PrimaryContactPersonID);
            ViewBag.BuyingGroupID = new SelectList(db.BuyingGroups, "BuyingGroupID", "BuyingGroupName", customer.BuyingGroupID);
            ViewBag.CustomerCategoryID = new SelectList(db.CustomerCategories, "CustomerCategoryID", "CustomerCategoryName", customer.CustomerCategoryID);
            ViewBag.BillToCustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", customer.BillToCustomerID);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryCityID = new SelectList(db.Cities, "CityID", "CityName", customer.DeliveryCityID);
            ViewBag.PostalCityID = new SelectList(db.Cities, "CityID", "CityName", customer.PostalCityID);
            ViewBag.DeliveryMethodID = new SelectList(db.DeliveryMethods, "DeliveryMethodID", "DeliveryMethodName", customer.DeliveryMethodID);
            ViewBag.AlternateContactPersonID = new SelectList(db.People, "PersonID", "FullName", customer.AlternateContactPersonID);
            ViewBag.LastEditedBy = new SelectList(db.People, "PersonID", "FullName", customer.LastEditedBy);
            ViewBag.PrimaryContactPersonID = new SelectList(db.People, "PersonID", "FullName", customer.PrimaryContactPersonID);
            ViewBag.BuyingGroupID = new SelectList(db.BuyingGroups, "BuyingGroupID", "BuyingGroupName", customer.BuyingGroupID);
            ViewBag.CustomerCategoryID = new SelectList(db.CustomerCategories, "CustomerCategoryID", "CustomerCategoryName", customer.CustomerCategoryID);
            ViewBag.BillToCustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", customer.BillToCustomerID);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CustomerName,BillToCustomerID,CustomerCategoryID,BuyingGroupID,PrimaryContactPersonID,AlternateContactPersonID,DeliveryMethodID,DeliveryCityID,PostalCityID,CreditLimit,AccountOpenedDate,StandardDiscountPercentage,IsStatementSent,IsOnCreditHold,PaymentDays,PhoneNumber,FaxNumber,DeliveryRun,RunPosition,WebsiteURL,DeliveryAddressLine1,DeliveryAddressLine2,DeliveryPostalCode,DeliveryLocation,PostalAddressLine1,PostalAddressLine2,PostalPostalCode,LastEditedBy,ValidFrom,ValidTo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeliveryCityID = new SelectList(db.Cities, "CityID", "CityName", customer.DeliveryCityID);
            ViewBag.PostalCityID = new SelectList(db.Cities, "CityID", "CityName", customer.PostalCityID);
            ViewBag.DeliveryMethodID = new SelectList(db.DeliveryMethods, "DeliveryMethodID", "DeliveryMethodName", customer.DeliveryMethodID);
            ViewBag.AlternateContactPersonID = new SelectList(db.People, "PersonID", "FullName", customer.AlternateContactPersonID);
            ViewBag.LastEditedBy = new SelectList(db.People, "PersonID", "FullName", customer.LastEditedBy);
            ViewBag.PrimaryContactPersonID = new SelectList(db.People, "PersonID", "FullName", customer.PrimaryContactPersonID);
            ViewBag.BuyingGroupID = new SelectList(db.BuyingGroups, "BuyingGroupID", "BuyingGroupName", customer.BuyingGroupID);
            ViewBag.CustomerCategoryID = new SelectList(db.CustomerCategories, "CustomerCategoryID", "CustomerCategoryName", customer.CustomerCategoryID);
            ViewBag.BillToCustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", customer.BillToCustomerID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
    }
}
