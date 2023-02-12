using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace climate_API.Classes.Util
{
    public static class consumirLog
    {
        public static void crearRegistroLog(string valInstance, string valMessageLog)
        {
            CreacionLog objLog = CreacionLog.instance(valInstance);
            objLog.escribirLog(valMessageLog);
        }
    }
}