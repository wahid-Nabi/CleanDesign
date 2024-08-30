using CleanDesign.SharedKernel;

namespace CleanDesign.Presentation.Errors
{
    public static class ApplicationErrors
    {
        public static readonly Error InternalServerError = new(
            "App.InternalServerError",
            "Internal server error occured!");
    }
}
