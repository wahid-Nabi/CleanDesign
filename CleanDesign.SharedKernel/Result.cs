namespace CleanDesign.SharedKernel
{
    public class Result
    {
        protected Result(bool isSuccess, Error error)
        {

            if (isSuccess && error != Error.None)
            {
                throw new InvalidOperationException();
            }
            if (!isSuccess && error == Error.None)
            {
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; private set; }

        public static Result Success() => new Result(true, Error.None);
        public static Result Failure(Error error) => new(false, error);

        public static Result<T> Success<T> (T value) => new(value, true, Error.None);

        public static Result<T> Failure<T>(Error error) => new(default, false, error);




    }
}
