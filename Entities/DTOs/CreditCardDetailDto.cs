using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CreditCardDetailDto :IDto
    {
        public int CreditCardId { get; set; }

        public int CustomerId { get; set; }

        public string CardNumber { get; set; }

        public string CardCvv { get; set; }

        public string ExpirationDate { get; set; }

        public string NameOnTheCard { get; set; }

        public decimal MoneyInTheCard { get; set; }
    }
}
