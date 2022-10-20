using Core.Results.Abstract;
using Core.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult()
        {
        }

        // Tablo Döndürmeyen Metotların mesajlarını Result Taşıyacaktır.
        // Tablo döndüren metotların mesajlarını ve tablolarını DataResult Taşıyacaktır.
        public DataResult(ResultStatus status,string message,T data)
        {
            ResultStatus = status;
            Message = message;
            Data = data;
        }
        public DataResult(ResultStatus status, string message, T data,Exception exception)
        {
            ResultStatus = status;
            Message = message;
            Data = data;
            Exception = exception;
        }
        public T Data { get; }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
