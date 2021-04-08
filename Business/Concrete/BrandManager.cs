using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("brand.add,admin")]
        public IResult Add(Brand brand)
        {
          _brandDal.Add(brand);

            return new SuccessResult(Messages.Added);
        }


        [SecuredOperation("brand.delete,admin")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);

            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandsListed);
        }

        public IDataResult<List<Brand>> GetBrandsByBrandId(int id)
        {
            return  new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == id));
        }


        [SecuredOperation("brand.update,admin")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
           
            return new SuccessResult(Messages.Updated);
        }
    }
}
