using API.DTO.Product;
using FluentValidation;

namespace API.Validator.Product
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