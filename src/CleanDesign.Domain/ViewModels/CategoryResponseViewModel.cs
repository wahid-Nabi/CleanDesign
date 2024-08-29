
namespace CleanDesign.Application.ViewModels
{
    public class CategoryResponseViewModel
    {
        public required string Name { get; set; }
        public Guid CategoryId { get; set; }
        public string? Description { get; set; }

    }
}
