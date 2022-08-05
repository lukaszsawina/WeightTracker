using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Utilities
{
    public class WeightValidator: AbstractValidator<IWeightModel>
    {
        [Obsolete]
        public WeightValidator()
        {
            RuleFor(x => x.Weight)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .Must(BeAValidWeight).WithMessage("{PropertyName} has incorrect value");
        }
        protected bool BeAValidWeight(float weigth)
        {
            return weigth > 0;
        }
    }
}
