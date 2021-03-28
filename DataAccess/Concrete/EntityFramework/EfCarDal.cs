using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join ca in context.CarImages
                             on c.CarId equals ca.CarId

                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId=b.BrandId,
                                 ColorId=co.ColorId,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ColorName = co.ColorName,
                                 ImagePath = ca.ImagePath,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description
                             };
                return result.ToList();

            }
        }

    }
}
