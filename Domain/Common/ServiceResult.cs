using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class ServiceResult
    {
        public bool Succeeded { get; protected set; }
        public string ErrorMessage { get; protected set; }

        protected ServiceResult(bool succeeded, string errorMessage)
        {
            Succeeded = succeeded;
            ErrorMessage = errorMessage;
        }

        public static ServiceResult Success =>
            new ServiceResult(true, string.Empty);

        public static ServiceResult Fail(string errorMessage) =>
            new ServiceResult(false, errorMessage);
    }

    public class ServiceResult<TResult>
    {
        public bool Succeeded { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public TResult? Data { get; protected set; }

        protected ServiceResult(bool succeeded, string errorMessage, TResult data)
        {
            Succeeded = succeeded;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public static ServiceResult<TResult> Success(TResult result) =>
            new ServiceResult<TResult>(true, string.Empty, result);

        public static ServiceResult<TResult> Fail(string errors) =>
            new ServiceResult<TResult>(false, errors, default);
    }
}
