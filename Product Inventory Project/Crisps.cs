using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chips
{
    class Crisps : Product
    {
        public Crisps(int id, double price, int quantity, string name)
            : base(id, price, quantity, name)
        {

        }
        public Crisps(double price) : base(price)
        {

        }
    }
}
