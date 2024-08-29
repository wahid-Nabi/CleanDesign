
using CleanDesign.Application.ViewModels;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Queries.GetByIdCategoryQuery
{
    public class GetCategoryByIdQuery : IRequest<Result<CategoryResponseViewModel>>
    {
        public Guid CategoryId { get; set; }
    }
}
