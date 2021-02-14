using Buisness.Abstract;
using Buisness.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICustomerDal _customerDal;
        

        public RentalManager(IRentalDal rentalDal,ICustomerDal customerDal)
        {
            _rentalDal = rentalDal;
            _customerDal = customerDal;
        }
        public IResult Add(Rental rental)
        {
            if (_customerDal.Get(c=>c.Id == rental.CustomerId) != null) // Böyle bir müşteri varsa
            {
                if (rental.ReturnDate == null)
                {
                    return new ErrorResult(Messages.RentalIsNotReturned);
                }
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            return new ErrorResult(Messages.CustomerNotFound);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id == id));

        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);

        }
    }
}
