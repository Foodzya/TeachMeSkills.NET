using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cola
{
    class Coca_Cola : Product
    {
        public Coca_Cola(int id, double price, int quantity, string name)
            : base(id, price, quantity, name)
        {

        }
        public Coca_Cola(double price) : base(price)
        {

        }
    }
}
