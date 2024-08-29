using CleanDesign.Application.ViewModels;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Queries.CategoryQuerys
{
    public class GetCategoriesQuery : IRequest<Result<List<CategoryResponseViewModel>>>
    {

    }
}
