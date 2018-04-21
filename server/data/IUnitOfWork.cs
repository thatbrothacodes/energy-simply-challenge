using server.data.models;
using server.data.repositories;

namespace server.data {
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IPlanRepository PlanRepository { get; }
        void Save();
    }
}