using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Repo
{
    public interface IContactRepo
    {
        Contact Create(Contact contact);
        List<Contact> Read();
        Contact Read(int id);
        bool Update(Contact contact);
        bool Delete(Contact contact);
    }
}
