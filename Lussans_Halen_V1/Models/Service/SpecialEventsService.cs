using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models.Repo;
using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Service
{
    public class SpecialEventsService : ISpecialEventsService
    {

        private readonly ISpecialEventsRepo _specialEventsRepo;

        public SpecialEventsService(ISpecialEventsRepo specialEventsRepo)
        {
            _specialEventsRepo = specialEventsRepo;
        }

        public SpecialEvent Add(CreateSpecialEventsViewModel specialEvent)
        {
            SpecialEvent _specialEvents = new SpecialEvent()
            {
                SpecialEventsId = 0,
                SpecialEventsInfoName = specialEvent.SpecialEventsName,
                SpecialEventsDiscription = specialEvent.SpecialEventsDiscription
            };

            _specialEventsRepo.Create(_specialEvents);

            return _specialEvents;
        }

        public List<SpecialEvent> All()
        {
            return _specialEventsRepo.Read();
        }

        public bool Edit(int id, CreateSpecialEventsViewModel specialEvent)
        {
            SpecialEvent _specialEvent = _specialEventsRepo.Read(id);
            _specialEvent.SpecialEventsId = id;
            _specialEvent.SpecialEventsInfoName = specialEvent.SpecialEventsName;
            _specialEvent.SpecialEventsDiscription = specialEvent.SpecialEventsDiscription;


            return _specialEventsRepo.Update(_specialEvent);
        }

        public SpecialEvent FindById(int id)
        {
            return _specialEventsRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return _specialEventsRepo.Delete(FindById(id));
        }

        public List<SpecialEvent> Search(string search)
        {
            List<SpecialEvent> _specialEvents = new List<SpecialEvent>();

            foreach(SpecialEvent specialEvent in _specialEventsRepo.Read())
            {
                if(specialEvent.SpecialEventsInfoName == search)
                {
                    _specialEvents.Add(specialEvent);
                }
            }

            return _specialEvents;
        }
    }
}
