using BookstoreWeb.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Entities.Abstract
{
    public abstract class ProductBase : EntityBase
    {

        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual string Picture { get; set; }
        public virtual string Issue { get; set; }

    }
}
