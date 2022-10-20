using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Abstract
{
    // Generic Table => Hangi Tabloyu verirsem Döndürsün.
    // Eğer iki veya daha fazla geriye değer döndürmek istiyorsak out parametresini kullanırız.
    public interface IDataResult<out T>:IResult
    {
        // new DataResult<Products>(ResultStatus.Success,products);
        public T Data { get; }
    
    }
}
