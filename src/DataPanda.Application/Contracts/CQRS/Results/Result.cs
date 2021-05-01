using System.Threading.Tasks;

namespace DataPanda.Application.Contracts.CQRS.Results
{
    public class Result
    {
        protected Result(bool succeeded, string failurePayload)
        {
            Succeeded = succeeded;
            FailurePayload = failurePayload;
        }

        public static Result Success() => new(true, default!);

        public static Result Failure(string failurePayload) => new(false, failurePayload);

        public static Result<TSuccessPayload> Success<TSuccessPayload>(TSuccessPayload successPayload) => new(true, default!, successPayload);

        public static Result<TSuccessPayload> Failure<TSuccessPayload>(string failurePayload) => new(true, failurePayload, default!);

        public bool Succeeded { get; }

        public string FailurePayload { get; }

        public static implicit operator Result(string failurePayload) => Failure(failurePayload);

        public static implicit operator Task<Result>(Result result) => Task.FromResult(result);
    }

    public class Result<TSuccessPayload> : Result
    {
        public Result(bool succeeded, string failurePayload, TSuccessPayload successPayload) : base(succeeded, failurePayload)
        {
            SuccessPayload = successPayload;
        }

        public TSuccessPayload SuccessPayload { get; }

        public static implicit operator Result<TSuccessPayload>(TSuccessPayload successPayload) => Success(successPayload);

        public static implicit operator Result<TSuccessPayload>(string failurePayload) => Failure<TSuccessPayload>(failurePayload);

        public static implicit operator Task<Result<TSuccessPayload>>(Result<TSuccessPayload> result) => Task.FromResult(result);
    }
}
