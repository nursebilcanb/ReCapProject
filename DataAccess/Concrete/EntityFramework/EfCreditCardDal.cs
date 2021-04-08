using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, RentCarContext>, ICreditCardDal
    {
        public List<CreditCardDetailDto> GetCreditCardDetails(Expression<Func<CreditCard, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from card in filter == null ? context.CreditCards : context.CreditCards.Where(filter)
                             join customer in context.Customers
                             on card.CustomerId equals customer.CustomerId

                             select new CreditCardDetailDto
                             {
                                 CreditCardId = card.CardId,
                                 CustomerId = customer.CustomerId,
                                 CardCvv = card.CardCvv,
                                 CardNumber = card.CardNumber,
                                 MoneyInTheCard = card.MoneyInTheCard,
                                 NameOnTheCard = card.NameOnTheCard,
                                 ExpirationDate = card.ExpirationDate
                             };
                return result.ToList();
                             
            }
        }
    }
}
