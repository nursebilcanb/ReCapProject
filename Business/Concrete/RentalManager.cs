using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentaldal;
        private ICustomerService _customerService;
        private ICarService _carService;

        public RentalManager(IRentalDal rentaldal, ICarService carService, ICustomerService customerService)
        {
            _rentaldal = rentaldal;
            _carService = carService;
            _customerService = customerService;
        }


        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfCarRented(rental),
                FindexPointCheck(rental.CustomerId, rental.CarId));

            if (result != null)
            {
                return result;
            }
            _rentaldal.Add(rental);

            return new SuccessResult(Messages.Added);
        }


        public IResult Delete(Rental rental)
        {
            _rentaldal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(r => r.CarId == carId));
        }

        public IDataResult<List<Rental>> GetById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(r => r.RentalId == id));
        }

        public IResult Update(Rental rental)
        {
            _rentaldal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }


        private IResult CheckIfCarRented(Rental rental)
        {
            var result = _rentaldal.GetAll(
                r => r.CarId == rental.CarId &&
                (r.ReturnDate == null || r.ReturnDate < DateTime.Now)
                ).Any();

            if (result)
            {
                return new ErrorResult(Messages.CarAlreadyRented);
            }

            return new SuccessResult();
        }


        private IResult FindexPointCheck(int customerId, int carId)
        {
            var customer = _customerService.GetById(customerId).Data;

            if (customer.FindexPoint == 0)
            {
                return new ErrorResult(Messages.CustomerFindexPointIsZero);
            }

            var car = _carService.GetById(carId).Data;

            if (customer.FindexPoint < car.FindexPoint)
            {
                return new ErrorResult(Messages.CustomerScoreInvalid);
            }

            customer.FindexPoint = (car.FindexPoint / 2) + customer.FindexPoint;

            _customerService.Update(customer);
            return new SuccessResult();
        }
    }
}
