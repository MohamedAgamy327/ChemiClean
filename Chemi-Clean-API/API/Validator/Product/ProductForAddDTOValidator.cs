using API.DTO.Product;
using FluentValidation;

namespace API.Validator.Product
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