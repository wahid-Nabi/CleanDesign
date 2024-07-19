namespace CleanDesign.SharedKernel
{
    public class Result<T> : Result
    {
        private readonly T _value;
        public Result(T value ,bool isSuccess, Error error) : base(isSuccess, error)
        {

            _value = value;
        }

        public T Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");
    }
}
