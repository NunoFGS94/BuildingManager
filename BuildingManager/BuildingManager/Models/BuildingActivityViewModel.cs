using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace BuildingManager.Models
{
    public class BuildingActivityViewModel
    {
        public int Id { get; set; }

        public string Motive { get; set; }

        [Display(Name = "Exit Date")]
        [DataType(DataType.DateTime)]
        public DateTime? ExitDate { get; set; }

        [Display(Name = "Arrival Date")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Expected Exit Date")]
        [DataType(DataType.DateTime)]
        public DateTime ExpectedExitDate { get; set; }

        [Display(Name = "User Id")]
        public string IdentificationNumber { get; set; }

        public bool OverTime { get { return ExpectedExitDate <= DateTime.Now; } }

        public bool exited { get; set; }
    }

    public class BuildingActivityViewModelValidator : AbstractValidator<BuildingActivityViewModel>
    {
        public BuildingActivityViewModelValidator()
        {
            RuleFor(b => b.Motive).NotEmpty();
            RuleFor(b => b.ExpectedExitDate).NotEmpty();
            RuleFor(b => b.ExpectedExitDate).GreaterThan(DateTime.Now);
        }
    }
}
