using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract_9
{
    internal class People
    {
        public string Name { get; set; }
        public int Kol {  get; set; }
        public double Stoim { get; set; }

        public People(string name, int kol, double stoim)
        {
            Name = name;
            Kol = kol;
            Stoim = stoim;
        }
        public People()
        {
            Name = "";
            Kol = 0;
            Stoim = 0;
        }
        public override string ToString()
        {
            return Name + " " + Kol.ToString() + " " +Stoim.ToString() ;
        }
    }
}
