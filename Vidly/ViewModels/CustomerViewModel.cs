using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerViewModel
    {
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customers { get; set; }
    }
}