using CleanDesign.Application.Interfaces;
using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Entities;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Commands.Products.CreateProductCommand
{
    public class ProductCommandHandler : IRequestHandler<ProductCommand, Result<ProductResponseViewModel>>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public ProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }
        public async Task<Result<ProductResponseViewModel>> Handle(ProductCommand request, CancellationToken cancellationToken)
        {
            // Mapping product cammand to product class
            Product product = new()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                Deleted = false

            };
            if (request.Categories != null && request.Categories.Count > 0)
            {
                product.Categories = await _repository.GetCategoryByIds(request.Categories);

            }


            Product createdProduct = await _repository.CreateAsync(product);

            if (createdProduct == null)
            {
                return Result.Failure<ProductResponseViewModel>(Error.NullValue);

            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var productResponseVM = MapToResponseViewModel(createdProduct);

            return Result.Success<ProductResponseViewModel>(productResponseVM);

        }
        private ProductResponseViewModel MapToResponseViewModel(Product product)
        {

            return new ProductResponseViewModel()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Categories = product.Categories.Select(c => new CategoryResponseViewModel
                {
                    Name = c.Name,
                    Description = c.Description,
                    CategoryId = c.Id
                }).ToList()
            };
        
        }
    }
}
