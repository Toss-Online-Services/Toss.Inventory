using FluentValidation;

namespace Application.Features.Product.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductCommandValidator()
    {
    }
}
