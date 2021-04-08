using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            var result = CheckCreditCard(creditCard);

            if (result)
            {
                return new SuccessResult();
            }

            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<List<CreditCard>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IDataResult<List<CreditCard>> GetCardsByCustomerId(int customerId)
        {
            var result = _creditCardDal.GetAll(card => card.CustomerId == customerId);
            return new SuccessDataResult<List<CreditCard>>(result);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.Updated);
        }

        private bool CheckCreditCard(CreditCard card)
        {
            var beforeExist = _creditCardDal.GetAll(c => c.CustomerId == card.CustomerId);
            
            if(beforeExist.Count > 0)
            {
                var currentCard = _creditCardDal.Get(c => c.CardNumber == card.CardNumber);

                if (currentCard != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
