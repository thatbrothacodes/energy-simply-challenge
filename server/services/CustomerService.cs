using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using server.data;
using server.data.models;
using System;

namespace server.services {

    public class CustomerService : ICustomerService
    {
        IUnitOfWork _unitOfWork;
        public async Task<Customer> addCustomer(Customer customer)
        {
            return await this._unitOfWork.CustomerRepository.AddAsyn(customer);
        }

        public async Task<List<Customer>> getCustomers(int page, int pageSize)
        {
             var items = await this._unitOfWork.CustomerRepository.GetAllAsync();
             return items.Skip(page).Take(pageSize).ToList();
        }

        public async Task<Customer> updateCustomer(Customer customer)
        {
            return await this._unitOfWork.CustomerRepository.UpdateAsyn(customer, customer.CustID);
        }

        public CustomerService(IUnitOfWork unitOfWork) {
            this._unitOfWork = unitOfWork;
        }
    }
    public interface ICustomerService {
        Task<List<Customer>> getCustomers(int page, int pageSize);
        Task<Customer> addCustomer(Customer customer);
        Task<Customer> updateCustomer(Customer customer);
    }
}