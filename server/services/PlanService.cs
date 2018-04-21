using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using server.data;
using server.data.models;

namespace server.services {

    public class PlanService : IPlanService
    {
        IUnitOfWork _unitOfWork;
        public async Task<Plan> addPlan(Plan plan)
        {
            return await this._unitOfWork.PlanRepository.AddAsyn(plan);
        }

        public async Task<List<Plan>> getPlans(int page, int pageSize)
        {
             var items = await this._unitOfWork.PlanRepository.GetAllAsync();
             return items.Skip(page).Take(pageSize).ToList();
        }

        public async Task<Plan> updatePlan(Plan plan)
        {
            return await this._unitOfWork.PlanRepository.UpdateAsyn(plan, plan.PlanID);
        }

        public PlanService(IUnitOfWork unitOfWork) {
            this._unitOfWork = unitOfWork;
        }
    }
    public interface IPlanService {
        Task<List<Plan>> getPlans(int page, int pageSize);
        Task<Plan> addPlan(Plan plan);
        Task<Plan> updatePlan(Plan plan);
    }
}