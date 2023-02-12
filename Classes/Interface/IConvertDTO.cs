using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace climate_API.Classes.Interface
{
    public interface IConvertDTO<T,B> where T : class
    {
        B CONVERT_DTO(T OBJ);
    }
}
