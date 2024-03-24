﻿namespace lovedmemory.Application.Common.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public IEnumerable<string> Errors { get; }

        protected Result(bool isSuccess, T value, IEnumerable<string> errors)
        {
            IsSuccess = isSuccess;
            Value = value;
            Errors = errors;
        }

        public static Result<T> Success(T value) =>
            new(true, value, Enumerable.Empty<string>());

        public static Result<T> Failure(IEnumerable<string> errors) =>
            new Result<T>(false, default, errors);
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
