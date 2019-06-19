using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSP19._06._19
{
    public class Clothes
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; }
        public string Gender { get; set; }
        public int Size { get; set; }
        public string Country { get; set; }
        public int Price { get; set; }
    }
}
