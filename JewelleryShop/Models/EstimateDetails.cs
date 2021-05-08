using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JewelleryShop.Models
{
    public class EstimateDetails
    {
        public int EstimateId { get; set; }        
        public double GoldPrice { get; set; }
        [Required]
        public double GoldWeight { get; set; }
        public double DiscountPrice { get; set; }
        public double TotalPrice { get; set; }
        public bool isPrivilaged { get; set; }
    }
}
