namespace DataPanda.Application.Contracts.CQRS.Results
{
    public class Result
    {
        protected Result(bool succeeded, string? failurePayload)
        {
            Succeeded = succeeded;
            FailurePayload = failurePayload;
        }

        public static Result Success() => new(true, default);

        public static Result Failure(string failurePayload) => new(false, failurePayload);

        public static Result<TSuccessPayload> Success<TSuccessPayload>(TSuccessPayload successPayload) => new(true, default, successPayload);

        public static Result<TSuccessPayload> Failure<TSuccessPayload>(string failurePayload) => new(true, failurePayload, default);

        public bool Succeeded { get; }

        public string? FailurePayload { get; }
    }

    public class Result<TSuccessPayload> : Result
    {
        public Result(bool succeeded, string? failurePayload, TSuccessPayload? successData) : base(succeeded, failurePayload)
        {
            SuccessPayload = successData;
        }

        public TSuccessPayload? SuccessPayload { get; }
    }
}
