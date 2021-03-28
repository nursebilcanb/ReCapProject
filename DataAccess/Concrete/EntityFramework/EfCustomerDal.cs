﻿using Core.DataAccess.EntityFramework;
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
    public class EfCustomerDal :EfEntityRepositoryBase<Customer,RentCarContext>, ICustomerDal
    {

        public  List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from cs in filter == null ? context.Customers : context.Customers.Where(filter)
                             join u in context.Users
                             on cs.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = cs.CustomerId,
                                 UserId = u.Id,
                                 CompanyName = cs.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 Status = u.Status
                             };
                return result.ToList();
            }
        }
    }
}
