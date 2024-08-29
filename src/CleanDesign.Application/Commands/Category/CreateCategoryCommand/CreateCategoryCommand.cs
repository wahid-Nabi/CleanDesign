using CleanDesign.Application.ViewModels;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Commands.Category.CreateCategoryCommand
{
    public class CreateCategoryCommand : IRequest<Result<CategoryResponseViewModel>>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

    }
}
