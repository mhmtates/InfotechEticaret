using Core.Results.Abstract;
using Core.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Concrete
{
    public class Result : IResult
    {
        // Sadece ve sadece Constructor ile içerisine veri atacağımdan dolayı.
        // Sınıf türetilip içerisine veri atılmasın diye.

        // Metotların Aşırı Yüklenmesi Overloading
        public Result(ResultStatus status, string message)
        {
            ResultStatus = status;
            Message = message;
        }

        public Result(ResultStatus status, string message,Exception exception)
        {
            ResultStatus = status;
            Message = message;
            Exception = exception;
        }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
