using CleanDesign.Application.Commands.Products.CreateProductCommand;
using CleanDesign.Application.Design_Principals;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanDesign.Presentation.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediater;
        public ProductsController(IMediator mediater)
        {
            _mediater = mediater;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateAsync(ProductCommand command)
        {
            var result = await _mediater.Send(command);
            return Ok(result);
        }

        
    }
}
