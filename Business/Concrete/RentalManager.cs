using Business.Abstract;
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
    public class RentalManager :IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.RentDate.DayOfYear > 0)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.NotAdded);
            }
        }

        public IResult Delete(Rental rental)
        {
            if (rental.RentalId != 0)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.Deleted);
            }
            else
            {
                return new ErrorResult(Messages.NotDeleted);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<Rental>>(_rentalDal.GetAll(), true, Messages.Listed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 23)
            {
                return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
            }
            return new DataResult<Rental>(_rentalDal.Get(c => c.RentalId == id), true, Messages.Listed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
