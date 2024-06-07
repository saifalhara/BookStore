using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Abstractions;

public  class Result
{
    public bool IsSuccess { get; }
    public bool IsError =>  !IsSuccess;
    public object? Response { get; set; }
    public Error? Error { get; }

    private Result(bool isSuccess, Error? error = default , object? response = default )
    {
        if (isSuccess && error != Error.None ||
          !isSuccess && error == Error.None)
        {
            throw new Exception("Invalid error");
        }
        this.Response = response;
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success(object? response = default) => new(true, Error.None , response);
    public static Result Failure(Error? error = default) => new(false, error);
}
