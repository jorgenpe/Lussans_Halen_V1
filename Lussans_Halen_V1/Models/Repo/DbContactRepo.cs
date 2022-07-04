using System.Collections.Generic;
using Lussans_Halen_V1.Data;
using System.Linq;

namespace Lussans_Halen_V1.Models.Repo
{
    public class DbContactRepo : IContactRepo
    {
        readonly LussansDbContext _lussansDbContext;

        public DbContactRepo(LussansDbContext lussansDbContext)
        {
            _lussansDbContext = lussansDbContext;
        }

        public Contact Create(Contact contact)
        {
            _lussansDbContext.Add(contact);
            _lussansDbContext.SaveChanges();

            return contact;
        }

        public bool Delete(Contact contact)
        {
            _lussansDbContext.Remove(contact);

            int change = _lussansDbContext.SaveChanges();

            if (change == 2) { return true; }

            return false;
        }

        public List<Contact> Read()
        {
            if(_lussansDbContext == null)
            {
                return null;
            }
            return _lussansDbContext.Contacts.ToList();
        }

        public Contact Read(int id)
        {
            if (_lussansDbContext == null)
            {
                return null;
            }
            return _lussansDbContext.Contacts.SingleOrDefault(p => p.ContactId == id);
        }

        public bool Update(Contact contact)
        {
            _lussansDbContext.Update(contact);

            int change = _lussansDbContext.SaveChanges();

            if (change == 2) 
            { 
                return true; 
            }

            return false;
        }
    }
}
