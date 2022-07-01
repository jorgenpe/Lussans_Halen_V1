using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models.Repo;
using System.Collections.Generic;


namespace Lussans_Halen_V1.Models.Service
{
    public class AccessoriesService : IAccessoriesService
    {
        private readonly IAccessoriesRepo _accessoriesRepo;

        public AccessoriesService(IAccessoriesRepo accessoriesRepo)
        {
            _accessoriesRepo = accessoriesRepo;
        }

        public Accessory Add(CreateAccessoriesViewModel accessory)
        {
            Accessory _accessory = new Accessory()
            {
                AccessoryId = 0,
                AccessoryName = accessory.AccessoriesName
            };

            foreach(Accessory _Accessory in _accessoriesRepo.Read())
            {
                if(_Accessory.AccessoryName == accessory.AccessoriesName)
                {
                    _accessory.AccessoryId = _Accessory.AccessoryId;
                    return _accessory;

                }
            }
            return _accessoriesRepo.Create(_accessory);
        }

        public List<Accessory> All()
        {
            return _accessoriesRepo.Read();
        }

        public bool Edit(int id, CreateAccessoriesViewModel accessory)
        {
            Accessory _accessory = _accessoriesRepo.Read(id);

            if(_accessory != null)
            {
                _accessory.AccessoryName = accessory.AccessoriesName;
                return _accessoriesRepo.Update(_accessory);
            }
            return false;
        }

        public Accessory FindById(int id)
        {
            return _accessoriesRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Accessory _accessory = _accessoriesRepo.Read(id);

            if (_accessory != null)
            {
                return _accessoriesRepo.Delete(_accessory);
            }
            return false;
        }

        public List<Accessory> Search(string search)
        {
            List<Accessory> accessories = new List<Accessory>();

            foreach(Accessory accessory in _accessoriesRepo.Read())
            {
                if(accessory.AccessoryName == search) 
                {
                    accessories.Add(accessory); 
                }
            }
            return accessories;
        }
    }
}
