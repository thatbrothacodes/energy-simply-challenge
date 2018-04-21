using server.data.models;

namespace server.data.models
{
    public class Customer
    {
        public int CustID { get; set; }
        public string CustName { get; set; }
        public string CustEmail { get; set; }
        public int CustPlanID { get; set; }
        public virtual Plan Plan { get; set; }
    }
}