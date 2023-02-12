using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace climate_API.Classes.Interface
{
    public interface IReadable<T> where T : class
    {
        T GET(int ID);
        List<T> GETALL();
    }
}
