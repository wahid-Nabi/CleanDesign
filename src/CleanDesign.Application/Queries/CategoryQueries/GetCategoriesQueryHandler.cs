
using CleanDesign.Application.Interfaces;
using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Entities;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Queries.CategoryQuerys
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, Result<List<CategoryResponseViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _category;
        public GetCategoriesQueryHandler(IUnitOfWork unitOfWork, ICategoryRepository category)
        {
            _unitOfWork = unitOfWork;
            _category = category;
        }
        public async Task<Result<List<CategoryResponseViewModel>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {

            List<Category> categoryList = await _category.GetAsync();
            
            if (categoryList.Count < 0)
            {
                return Result.Failure<List<CategoryResponseViewModel>>(Error.NullValue);
            }

            var categories = categoryList.Select(x => new CategoryResponseViewModel()
            {
                Name = x.Name,
                CategoryId = x.Id
            }).ToList();

            return Result.Success<List<CategoryResponseViewModel>>(categories);
        }
    }
}
