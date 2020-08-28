using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.CustomValidation
{
    public class MinEighteenYearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.BirthDayDate == null)
                return new ValidationResult("Birthdate is required");
            var dateOfBirth = Convert.ToDateTime(customer.BirthDayDate);
            var age = DateTime.Today.Year - dateOfBirth.Year;
            return age > 18 ? ValidationResult.Success :new ValidationResult("Customer should be at least 18 years old");
        }
    }
}