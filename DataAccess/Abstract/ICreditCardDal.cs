using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{ 
    public interface ICreditCardDal : IEntityRepository<CreditCard>
    {
        List<CreditCardDetailDto> GetCreditCardDetails(Expression<Func<CreditCard, bool>> filter = null);
    }
}
