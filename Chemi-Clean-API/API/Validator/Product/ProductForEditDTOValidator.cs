using API.DTO.Contract;
using FluentValidation;

namespace API.Validator.Contract
{
    public class ProductForEditDTOValidator : AbstractValidator<ProductForEditDTO>
    {
        public ProductForEditDTOValidator()
        {
            RuleFor(x => x.Id)
                   .NotNull()
                   .NotEmpty();

            RuleFor(x => x.Name)
                   .NotNull()
                   .NotEmpty();
        }
    }
}