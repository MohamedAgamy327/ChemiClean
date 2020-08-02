using API.DTO.Contract;
using FluentValidation;

namespace API.Validator.Contract
{
    public class ProductForAddDTOValidator : AbstractValidator<ProductForAddDTO>
    {
        public ProductForAddDTOValidator()
        {
            RuleFor(x => x.Name)
                   .NotNull()
                   .NotEmpty();
        }
    }
}