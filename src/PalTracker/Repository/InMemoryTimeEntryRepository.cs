using System.Collections.Generic;
using System.Linq;
namespace PalTracker
{

    public class InMemoryTimeEntryRepository:ITimeEntryRepository
    {
        public int UniqueId { get; set; } = 1;
        public Dictionary<long, TimeEntry> _timeEntryDic { get; set; } = new Dictionary<long, TimeEntry>();

        public TimeEntry Create(TimeEntry timeEntry)
        {
            timeEntry.Id = UniqueId;
            _timeEntryDic.Add(UniqueId++, timeEntry);
            return timeEntry;

            //  var id = _timeEntryDic.Count + 1;

            // timeEntry.Id = id;

            // _timeEntryDic.Add(id, timeEntry);

            // return timeEntry;
        }
        public TimeEntry Find(long id) => _timeEntryDic[id];

        public bool Contains(long id)
        {
            return _timeEntryDic.ContainsKey(id);
        }

        public IEnumerable<TimeEntry> List()
        {
            return _timeEntryDic.Values.ToList();
        }

        public TimeEntry Update(long id, TimeEntry timeEntry)
        {
           if(Contains(id))
           {
               timeEntry.Id= id;
                _timeEntryDic[id]=timeEntry;
           } 

           return timeEntry;
        }

        public void Delete(long id)
        {
            if(Contains(id))
            {
                _timeEntryDic.Remove(id);
            }
        }
    }
}