using System.Collections.Generic;
using Lussans_Halen_V1.Models.ViewModels;

namespace Lussans_Halen_V1.Models.Service
{
    public interface IContactService
    {
        Contact Add(CreateContactViewModel contact);
        List<Contact> All();
        List<Contact> Search(string search);
        Contact FindById(int id);
        bool Edit(int id, CreateContactViewModel contact);
        bool Remove(int id);
    }
}
