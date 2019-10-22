using Microsoft.AspNetCore.Mvc;
using Salon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Salon.Controllers
{
    public class ClientsController : Controller
   {
        private readonly SalonContext _db;

        public ClientsController(SalonContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Client> model = _db.Clients.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            return View(thisClient);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
    
            Client thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            
            return View(thisClient);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            _db.Entry(client).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}