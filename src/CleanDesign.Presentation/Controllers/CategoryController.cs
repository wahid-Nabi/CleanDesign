using CleanDesign.Application.Commands.Category.CreateCategoryCommand;
using CleanDesign.Application.Queries.CategoryQuerys;
using CleanDesign.Application.Queries.GetByIdCategoryQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanDesign.Presentation.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());
            return Ok(result);
        }

        [HttpGet("CategoryId:Guid")]
        public async Task<IActionResult> CategoryAsync([FromQuery]Guid CategoryId)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery() { CategoryId = CategoryId });
            return Ok(result);
        }

    }
}
