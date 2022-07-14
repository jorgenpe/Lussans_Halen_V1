using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lussans_Halen_V1.Models.Service;
using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models;

namespace Lussans_Halen_V1.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }



        // GET: ContactController
        public ActionResult Index()
        {
            return View(_contactService.All());
        }

        public ActionResult PrivateIndex()
        {
            return View(_contactService.All());
        }


        // GET: ContactController/Create
        public ActionResult Create()
        {
            CreateContactViewModel createContact = new CreateContactViewModel();
            return View(createContact);
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateContactViewModel createContact)
        {
            try
            {
                if(ModelState.IsValid && createContact != null)
                {
                    _contactService.Add(createContact);

                    return RedirectToAction("PrivateIndex");
                }

                return View(createContact);
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateContactViewModel editContact)
        {
            try
            {
                Contact contact = new Contact();

                if(id == 0 && editContact.ContactId != 0)
                {
                    contact = _contactService.FindById(editContact.ContactId);
                }
                else
                {
                    contact = _contactService.FindById(id);
                }
                CreateContactViewModel newContact = new CreateContactViewModel();

                newContact.ContactId = id;
                newContact.ContactName = contact.ContactName;
                newContact.ExtenedContactName = contact.ExtenedContactName;
                newContact.PhoneNumber = contact.PhoneNumber;
                newContact.Email = contact.Email;
                newContact.Street = contact.Street;
                newContact.ZipCode = contact.ZipCode;
                newContact.City = contact.City;

                if(ModelState.IsValid && editContact.ContactId != 0)
                {
                    id = contact.ContactId;
                    _contactService.Edit(id,editContact);

                    return RedirectToAction("PrivateIndex");
                }

                return View(newContact);
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactService.Remove(id);

                }
                

                return RedirectToAction("PrivateIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}
