using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chick
{
    class Chicken : Product
    {
        public Chicken(int id, double price, int quantity, string name)
            : base(id, price, quantity, name)
        {

        }
        public Chicken(double price) : base(price)
        {

        }
    }
}
