using CleanDesign.Application.Interfaces;
using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Entities;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Queries.GetByIdCategoryQuery
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryResponseViewModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<CategoryResponseViewModel>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            Category catgory = await _categoryRepository.GetAsync(request.CategoryId);
            if (catgory == null)
            {
                return Result.Failure<CategoryResponseViewModel>(Error.NullValue);
            }

            CategoryResponseViewModel catgoryVM = new()
            {
                CategoryId= catgory.Id,
                Name= catgory.Name,
                Description= catgory.Description,
            };

            return Result<CategoryResponseViewModel>.Success(catgoryVM);
            
        }
    }
}
