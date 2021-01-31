using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple
{
    class Apples : Product
    {
        public Apples(int id, double price, int quantity, string name)
            : base(id, price, quantity, name)
        {

        }
        public Apples(double price) : base(price)
        {

        }
    }
}
