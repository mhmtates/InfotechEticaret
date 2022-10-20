using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.ComplexTypes
{
    public enum ResultStatus
    {
        // Değişkenlerin alabileceği değerleriin belli olduğu durumlarda programı daha okunabilir hale getirmek için kullanırız.

       Success = 0,
       Error = 1,
       Warning = 2, // ResultStatus.Warning
       Info = 3    // ResultStatus.Info

    }
}
