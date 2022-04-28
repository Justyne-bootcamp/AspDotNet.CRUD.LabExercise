using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CustomerData.Models
{
    public partial class Customer: BaseEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^(09[0-9]{9})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
