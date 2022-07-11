using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models.Repo;
using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Service
{
    public class ContactService : IContactService
    {

        private readonly IContactRepo _contactRepo;

        public ContactService(IContactRepo contactRepo)
        {
            _contactRepo = contactRepo;
        }

        public Contact Add(CreateContactViewModel contact)
        {
            Contact _contact = new Contact() { ContactId = 0, ContactName = contact.ContactName, ExtendedContactName = contact.ExtendedContactName,
                               PhoneNumber =  contact.PhoneNumber, Email = contact.Email, City = contact.City, Street = contact.Street, ZipCode = contact.ZipCode };
            _contactRepo.Create(_contact);
            return _contact;

        }

        public List<Contact> All()
        {
            return _contactRepo.Read();
        }

        public bool Edit(int id, CreateContactViewModel contact)
        {
            Contact _contact = new Contact()
            {
                ContactId = id,
                ContactName = contact.ContactName,
                ExtendedContactName = contact.ExtendedContactName,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email,
                City = contact.City,
                Street = contact.Street,
                ZipCode = contact.ZipCode
            };

            return _contactRepo.Update(_contact);
        }

        public Contact FindById(int id)
        {
            return _contactRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return _contactRepo.Delete(FindById(id));
        }

        public List<Contact> Search(string search)
        {
            List<Contact> _contacts = new List<Contact>();

            foreach(Contact contact in _contactRepo.Read())
            {
                if (contact.ContactName == search)
                {
                    _contacts.Add(contact);
                } else if (contact.ExtendedContactName == search)
                {
                    _contacts.Add(contact);
                } else if (contact.PhoneNumber == search)
                {
                    _contacts.Add(contact);
                }
                else if (contact.Email == search)
                {
                    _contacts.Add(contact);
                }else if(contact.City == search)
                {
                    _contacts.Add(contact);
                }else if( contact.Street == search)
                {
                    _contacts.Add(contact);
                }else if( contact.ZipCode == search)
                {
                    _contacts.Add(contact);
                }
            }
            return _contacts;
        }
    }
}
