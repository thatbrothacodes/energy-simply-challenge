using System.ComponentModel.DataAnnotations;

namespace server.data.models
{
    public class Plan
    {
        [Required]
        public int PlanID { get; set; }
        
        [Required]
        [Display(Name="Plan Name")]
        public string PlanName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name="Fixed Cost")]
        public decimal PlanFixedCost { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name="Variable Cost")]
        public decimal PlanVarCost { get; set; }
    }
}