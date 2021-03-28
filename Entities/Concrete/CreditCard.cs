using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard :IEntity
    {
        public int CardId { get; set; }

        public string CardNumber { get; set; }

        public string CardCvv { get; set; }

        public string ExpirationDate { get; set; }

        public string NameOnTheCard { get; set; }

        public decimal MoneyInTheCard { get; set; }

    }
}
