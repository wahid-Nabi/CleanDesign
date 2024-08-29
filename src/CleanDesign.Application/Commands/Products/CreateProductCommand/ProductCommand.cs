using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Entities;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Commands.Products.CreateProductCommand
{
    public class ProductCommand : IRequest<Result<ProductResponseViewModel>>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public List<string>? Categories { get; set; }

    }
}
