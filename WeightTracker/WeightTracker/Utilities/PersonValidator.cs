using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Utilities
{
    public class PersonValidator : AbstractValidator<IPersonModel>
    {
        [Obsolete]
        public PersonValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .Length(1, 50).WithMessage("{PropertyName} length is incorect ")
                .Must(BeAValidName).WithMessage("{PropertyName} has incorect characters");

            RuleFor(x => x.Age)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .Must(BeAValidAge).WithMessage("{PropertyName} has incorrect value");

            RuleFor(x => x.Height)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .Must(BeAValidHeight).WithMessage("{PropertyName} has incorrect value");
        }
        protected bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");

            return name.All(Char.IsLetter);
        }
        protected bool BeAValidAge(int age)
        {
            return age > 0 && age <= 120;
        }
        protected bool BeAValidHeight(int height)
        {
            return height > 0 && height <= 300;
        }
    }
}
