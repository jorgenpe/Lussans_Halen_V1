using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models.Repo;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Lussans_Halen_V1.Models.Service
{
    public class DishsAccessoriesService : IDishsAccessoriesService
    {

        private readonly IDishsAccessoriesRepo _DbDishsAccessoriesRepo;
        private readonly IDishService _dishService;

        public DishsAccessoriesService(IDishsAccessoriesRepo dishsAccessoriesRepo, IDishService dishService)
        {
            _DbDishsAccessoriesRepo = dishsAccessoriesRepo;
            _dishService = dishService; 

        }

        public DishAccessory Add(CreateDishsAccessoriesViewModel createDishAccessories)
        {
            if (_dishService.FindById(createDishAccessories.DishId) == null)
            {
                throw new ArgumentNullException("Id is not in database");
            }

            DishAccessory dishAccessory = new DishAccessory() 
            { 
                AccessoryId = createDishAccessories.AccessoryId,
                DishId = createDishAccessories.DishId
            };
            return _DbDishsAccessoriesRepo.Create(dishAccessory);

        }

        public List<DishAccessory> All()
        {
            return _DbDishsAccessoriesRepo.Read();
        }

      

        public DishAccessory FindById(CreateDishsAccessoriesViewModel dishAccessories)
        {
            DishAccessory dishAccessory = _DbDishsAccessoriesRepo
                .ReadByAccessoryId(dishAccessories.AccessoryId)
                .SingleOrDefault(d => d.DishId == dishAccessories.DishId);
            return dishAccessory;
        }

        public bool Remove(CreateDishsAccessoriesViewModel dishAccessories)
        {
            DishAccessory dishAccessory = _DbDishsAccessoriesRepo
                .ReadByAccessoryId(dishAccessories.AccessoryId)
                .SingleOrDefault(d => d.DishId == dishAccessories.DishId);
            
            if(dishAccessory != null)
            {
                return _DbDishsAccessoriesRepo.Delete(dishAccessory);
            }

            return false;
        }

        
    }
}
