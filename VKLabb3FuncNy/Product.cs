using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKLabb3FuncNy
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); 
        public string Name { get; set; }
        public int Price { get; set; }

    }
}
