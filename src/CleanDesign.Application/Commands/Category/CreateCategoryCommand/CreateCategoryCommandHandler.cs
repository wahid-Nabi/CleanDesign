using CleanDesign.Application.Interfaces;
using CleanDesign.Application.ViewModels;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Commands.Category.CreateCategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<CategoryResponseViewModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<CategoryResponseViewModel>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category category = new()
            {
                Name = request.Name,
                Description = request.Description ?? string.Empty,
                CreatedOn = DateTime.Now,
                Deleted = false,
                UpdatedOn = DateTime.Now,

            };

            var createdCategory = await _categoryRepository.CreateAsync(category);


            if (createdCategory == null)
            {
                return Result.Failure<CategoryResponseViewModel>(Error.NullValue);
            }

            await _unitOfWork.SaveChangesAsync();

            CategoryResponseViewModel categoryVM = new()
            {
                Name = request.Name,
                Description = request.Description ?? string.Empty,
                CategoryId = createdCategory.Id,
            };

            return Result.Success<CategoryResponseViewModel>(categoryVM);

        }
    }
}
