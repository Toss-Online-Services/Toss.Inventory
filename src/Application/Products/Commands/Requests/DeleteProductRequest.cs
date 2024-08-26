namespace Application.Products.Commands.Requests;
public record DeleteProductRequest(int Id) : IRequest<bool>;
