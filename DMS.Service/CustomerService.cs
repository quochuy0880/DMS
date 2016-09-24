using DMS.Data.Infrastructure;
using DMS.Data.Repositories;
using DMS.Model.Models;
using System.Collections.Generic;
using System;

namespace DMS.Service
{
    public interface ICustomerService
    {
        Customer Add(Customer customer);

        void Update(Customer customer);

        Customer Delete(int id);

        IEnumerable<Customer> GetAll();

        Customer GetById(int id);

        void Save();
    }

    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
        }

        public Customer Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public Customer Delete(int id)
        {
            return _customerRepository.Delete(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Customer customer)
        {
            _customerRepository.Update(customer);
        }
    }
}