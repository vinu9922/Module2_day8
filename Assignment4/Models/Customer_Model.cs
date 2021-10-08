using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Assignment4.Models
{
    public class Customer_Model
    {
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNo { get; set; }
        public string CustomerCity { get; set; }
    }
}
