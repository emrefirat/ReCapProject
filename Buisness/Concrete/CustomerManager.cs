using Buisness.Abstract;
using Buisness.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IUserDal _userDal;

        public CustomerManager(ICustomerDal customerDal, IUserDal userDal)
        {
            _customerDal = customerDal;
            _userDal = userDal;
        }

        public IResult Add(Customer customer)
        {

            if (_userDal.Get(u => u.Id == customer.UserId) != null) //Bu kullanıcı var mı?
            {
                if (_customerDal.Get(c=> c.UserId == customer.UserId && c.CompanyName == customer.CompanyName)== null) // Kullanıcıya ait aynı bir CompanyName yoksa 
                {
                    _customerDal.Add(customer);
                    return new SuccessResult(Messages.CustomerAdded);

                }
                return new ErrorResult(Messages.CustomerExistForTheUser);
            }
            return new ErrorResult(Messages.UserNotFound);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.AllCustomerListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id), Messages.GetCustomerById);

        }

        public IResult Update(Customer customer)
        {
            if (_customerDal.Get(c => c.Id == customer.Id) != null) // Customer varsa
            {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.CustomerUpdated);
            }
            return new ErrorResult(Messages.CustomerNotFound);
        }
    }
}
