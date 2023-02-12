using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace climate_API.Classes.Interface
{
    public interface IRemovable<T> where T : class 
    {
        void DELETE(long ID);
    }
}
