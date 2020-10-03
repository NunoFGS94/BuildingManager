using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManager.Models
{
    public class BuildingUser : IdentityUser<int>
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Identification Number")]
        [PersonalData]
        public int IdentificationNumber { get; set; }
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
    }

    public class BuildingUserValidator : AbstractValidator<BuildingUser>
    {
        public BuildingUserValidator()
        {
            RuleFor(b => b.FirstName).NotEmpty();
            RuleFor(b => b.FirstName).MinimumLength(3);
            RuleFor(b => b.LastName).NotEmpty();
            RuleFor(b => b.LastName).MinimumLength(3);
            RuleFor(b => b.IdentificationNumber).NotEmpty();
            RuleFor(b => b.IdentificationNumber.ToString()).MinimumLength(8);
            RuleFor(b => b.UserPassword).MinimumLength(8);
        }
    }

}
