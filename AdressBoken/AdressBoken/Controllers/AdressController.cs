using Adressboken.data;
using Adressboken.data.Models;
using AdressBoken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdressBoken.Controllers
{
    public class AdressController : Controller
    {
        private IAdressRepository Repository;
        public AdressController()
        {
            this.Repository = new AdressRepository();
        }

        public ActionResult Index()
        {

            return View();
        }

        
        public ActionResult GetAdresses()
        {
            return PartialView(Repository.GetAll()
                .Select(x =>
                new AdressViewModel(x)
            ).ToList().OrderByDescending(x => x.StreetName));
        }
        [HttpGet]
        public ActionResult GetAdress(Guid adressId)
        {
            var adress = new AdressViewModel(Repository.GetAdressById(adressId));
            return PartialView(adress);
        }
        public ActionResult ShowAddAdress()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddAdress(AdressViewModel NewAdress)
        {
            if (ModelState.IsValid)
            {
                var adress = new Adress
                {
                    AdressId = Guid.NewGuid(),
                    City = NewAdress.City,
                    StreetName = NewAdress.StreetName,
                    PostalNumber = NewAdress.PostalNumber,
                    Country = NewAdress.Country,
                    LastUpdated = DateTime.Now


                };

                Repository.Add(adress);

                return RedirectToAction("Index");
            }
            else
            {
                return PartialView(NewAdress);
            }
        }

        public ActionResult UpdateAdress(Guid AdressID)
        {
            var adressToUpdate = new AdressViewModel(Repository.GetAdressById(AdressID));
            return PartialView(adressToUpdate);
        }
        [HttpPost]
        public ActionResult UpdateAdress(AdressViewModel adressToUpdate)
        {
            if (ModelState.IsValid)
            {
                var updatedAdress = adressToUpdate.Transform();
                updatedAdress.LastUpdated = DateTime.Now;

                Repository.Add(updatedAdress);
                return RedirectToAction("Index");
            }
            else return View(adressToUpdate);
        }
        [HttpPost]
        public ActionResult Delete(Guid AdressId)
        {
            Repository.Delete(AdressId);
            return RedirectToAction("Index");
        }
    }
}