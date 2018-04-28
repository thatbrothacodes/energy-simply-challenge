using System.ComponentModel.DataAnnotations;
using server.data.models;

namespace server.data.models
{
    public class Customer
    {
        public int CustID { get; set; }
        
        [Required]
        public string CustName { get; set; }

        [Required]
        [EmailAddress]
        public string CustEmail { get; set; }

        [Required]
        public int CustPlanID { get; set; }
        public virtual Plan Plan { get; set; }
    }
}