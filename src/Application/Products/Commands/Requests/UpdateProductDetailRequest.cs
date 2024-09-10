namespace Application.Products.Commands.Requests;

public record UpdateProductDetailRequest : ProductCommand, IRequest<int>
{
    public int Id { get; set; }
}
