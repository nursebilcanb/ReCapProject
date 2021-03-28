using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IResult VerifyCard(CreditCard creditCard);

        IDataResult<List<CreditCard>> GetByCardNumber(string cardNumber);

        IResult Update(CreditCard creditCard);
    }
}
