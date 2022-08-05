using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models.Repo;
using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Service
{
    public class OpenTimesService : IOpenTimesService
    {

        private readonly IOpenTimesRepo _openTimesRepo;

        public OpenTimesService(IOpenTimesRepo openTimesRepo)
        {
            _openTimesRepo = openTimesRepo;
        }

        public OpenTimes Add(CreateOpenTimesViewModel openTimes)
        {
            OpenTimes _openTimes = new OpenTimes()
            {
                OpenTimesId = 0,
                OpenTime = openTimes.OpenTime,
                CloseTime = openTimes.CloseTime,
                DayMenuTimeStart = openTimes.DayMenuTimeStart,
                DayMenuTimeEnd = openTimes.DayMenuTimeEnd,
                Day = openTimes.Day,
                DayTimeOption = openTimes.DayTimeOption
            };

            _openTimesRepo.Create(_openTimes);
            return _openTimes;
        }

        public List<OpenTimes> All()
        {
            return _openTimesRepo.Read();
        }

        public bool Edit(int id, CreateOpenTimesViewModel openTimes)
        {
            OpenTimes _openTimes = _openTimesRepo.Read(id);

            _openTimes.OpenTimesId = id;
            _openTimes.OpenTime = openTimes.OpenTime;
            _openTimes.CloseTime = openTimes.CloseTime;
            _openTimes.DayMenuTimeStart = openTimes.DayMenuTimeStart;
            _openTimes.DayMenuTimeEnd = openTimes.DayMenuTimeEnd;
            _openTimes.Day = openTimes.Day;
            _openTimes.DayTimeOption = openTimes.DayTimeOption;

            return _openTimesRepo.Update(_openTimes);
        }

        public OpenTimes FindById(int id)
        {
            return _openTimesRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return _openTimesRepo.Delete(FindById(id));
        }

        public List<OpenTimes> Search(string search)
        {
            throw new System.NotImplementedException();
        }
    }
}

