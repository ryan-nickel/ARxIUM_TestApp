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

        public string Name { get; set; }

        public int Count { get; set; }

        public void Increment()
        {
            Count++;
        }

        public void Reset()
        {
            Count = 0;
        }
    }
}
