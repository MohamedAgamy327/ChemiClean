using API.DTO.Product;
using FluentValidation;

namespace API.Validator.Product
{
    public class ProductForFileDTOValidator : AbstractValidator<ProductForFileDTO>
    {
        public ProductForFileDTOValidator()
        {
            RuleFor(x => x.Id)
                   .NotNull()
                   .NotEmpty();

            RuleFor(x => x.File)
                   .NotNull()
                   .NotEmpty();
        }
    }
}