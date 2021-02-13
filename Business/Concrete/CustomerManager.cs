﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal) 
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            IUserDal userDal;
            if (customer.UserId>2)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.Added);

            }
            else
            {
                return new ErrorResult(Messages.NotAdded);
            }
        }

        public IResult Delete(Customer customer)
        {
            if (customer.UserId != 0)
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.Deleted);
            }
            else
            {
                return new ErrorResult(Messages.NotDeleted);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<Customer>>(_customerDal.GetAll(), true, Messages.Listed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<Customer>(Messages.MaintenanceTime);
            }
            return new DataResult<Customer>(_customerDal.Get(c => c.Id == id), true, Messages.Listed);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
