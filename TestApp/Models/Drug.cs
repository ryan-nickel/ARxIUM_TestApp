using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class Drug
    {
        public Drug()
        {
            Name = "Default";
        }

        public Drug(string name)
        {
            Name = name;
            Count = 0;
        }

        public delegate void DrugUpdatedEventHandler(string name, int count, int previousCount, DateTime lastChanged);

        public event DrugUpdatedEventHandler DrugUpdatedEvent;

        public string Name { get; set; }

        public int Count { get; set; }

        public int PreviousCount { get; set; }

        public DateTime LastChanged { get; set; } = DateTime.Now;

        public void Increment()
        {
            LastChanged = DateTime.Now;
            PreviousCount = Count;
            Count++;
            DrugUpdatedEvent?.Invoke(Name, Count, PreviousCount, LastChanged);
        }

        public void Reset()
        {
            LastChanged = DateTime.Now;
            PreviousCount = Count;
            Count = 0;
            DrugUpdatedEvent?.Invoke(Name, Count, PreviousCount, LastChanged);
        }
    }
}
