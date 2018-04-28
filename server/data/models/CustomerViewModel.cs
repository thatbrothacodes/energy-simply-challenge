using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using server.data.models;

namespace server.data.models
{
    public class CustomerViewModel
    {
        public int CustID { get; set; }
        
        [Required]
        [Display(Name="Name")]
        public string CustName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name="E-Mail")]
        public string CustEmail { get; set; }

        [Required]
        [Display(Name="Plan")]
        public int CustPlanID { get; set; }

        public List<Plan> Plans { get; set; }
    }
}