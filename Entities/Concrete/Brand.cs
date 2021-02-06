using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Brand :IEntity
    {
        public string BrandId { get; set; }

        public string BrandName { get; set; }
    }
}
