namespace lovedmemory.application.Common.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public string Error { get; }

        protected Result(bool isSuccess, T value, string error)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }

        public static Result<T> Success(T value) =>
            new(true, value, string.Empty);

        public static Result<T> Failure(string error) =>
            new Result<T>(false, default, error);
    }
}
//namespace CleanArchitecture.Application.Common.Models;

//public class Result
//{
//    internal Result(bool succeeded, IEnumerable<string> errors)
//    {
//        Succeeded = succeeded;
//        Errors = errors.ToArray();
//    }

//    public bool Succeeded { get; init; }

//    public string[] Errors { get; init; }

//    public static Result Success()
//    {
//        return new Result(true, Array.Empty<string>());
//    }

//    public static Result Failure(IEnumerable<string> errors)
//    {
//        return new Result(false, errors);
//    }
//}
