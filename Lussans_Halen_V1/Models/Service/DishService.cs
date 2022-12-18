using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models.Repo;
using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Service
{
    public class DishService : IDishService
    {
        private readonly IDishRepo _dishRepo;

        public DishService(IDishRepo dishRepo)
        {
            _dishRepo = dishRepo;
        }

        public Dish Add(CreateDishViewModel dish)
        {
            
            Dish _dish = new Dish()
                {
                    DishId = 0,
                    DishName = dish.DishName,
                    DishPrice = dish.DishPrice,
                    MenuType = dish.MenuType,
                    //AllergyInfo = dish.AllergyInfo
                };

            foreach(Dish _Dish in _dishRepo.Read())
            {
                if(_Dish.DishName == dish.DishName) 
                { 
                    _dish.DishId = dish.DishId;
                    return _dish;
                }
            }
            
            return _dishRepo.Create(_dish);
            
        }

        public List<Dish> All()
        {
            return _dishRepo.Read();
        }

        public bool Edit(int id, CreateDishViewModel dish)
        {

            Dish _dish = _dishRepo.Read(id);

            if (dish != null)
            {
                _dish.DishName = dish.DishName;
                _dish.MenuType = dish.MenuType;
                _dish.DishPrice = dish.DishPrice;

                return _dishRepo.Update(_dish);
            }
            return false;
        }

        public Dish FindById(int id)
        {
            return _dishRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return _dishRepo.Delete(FindById(id));
        }

        public List<Dish> Search(string search)
        {
            List<Dish> dishes = new List<Dish>();

            foreach(Dish dish in _dishRepo.Read())
            {
                dishes.Add(dish);
            }

            return dishes;
        }

    }
}
