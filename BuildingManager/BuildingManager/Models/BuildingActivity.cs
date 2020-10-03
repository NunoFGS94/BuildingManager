using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManager.Models
{
    public class BuildingActivity
    {
        public int Id { get; set; }

        public string Motive { get; set; }

        [Display(Name = "User Id")]
        public string IdentificationNumber { get; set; }

        [Display(Name = "Arrival Date")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Exit Date")]
        [DataType(DataType.DateTime)]
        public DateTime? ExitDate { get; set; }

        [Display(Name = "Expected Exit Date")]
        [DataType(DataType.DateTime)]
        public DateTime ExpectedExitDate { get; set; }

        public bool exited { get; set; }
    }

    public class BuildingActivityValidator : AbstractValidator<BuildingActivity>
    {
        public BuildingActivityValidator()
        {
            RuleFor(b => b.Motive).NotEmpty();
            RuleFor(b => b.ExpectedExitDate).NotEmpty();
            RuleFor(b => b.ExpectedExitDate).GreaterThan(DateTime.Now);
        }
    }
}
