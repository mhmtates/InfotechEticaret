using Core.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Abstract
{
    public interface IResult
    {
        // Ekle Güncelle Sil
        public ResultStatus ResultStatus { get; }
        public string Message { get; } // Kullanıcıya verilecek Cevap.
        public Exception Exception { get; } // Log Kaydı.
    }
}
