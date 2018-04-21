namespace server.data.models
{
    public class Plan
    {
        public int PlanID { get; set; }
        public string PlanName { get; set; }
        public decimal PlanFixedCost { get; set; }
        public decimal PlanVarCost { get; set; }
    }
}