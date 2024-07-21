namespace CleanDesign.SharedKernel
{
    public class Result<T> : Result
    {
        private readonly T? _value;
        public Result(T? value ,bool isSuccess, Error error) : base(isSuccess, error)
        {
            _value = value;
        }

        public T Value
        {
            get
            {
                return IsSuccess
            ? _value!
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");
            }
        }

        public static implicit operator Result<T>(T? value) => Create(value);
    }
}
