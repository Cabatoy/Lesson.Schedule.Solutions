using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.Extensions
{
    //TODO: Herhangi bir objeyi json stringine çevirir.
    public static class ObjectExtensions
    {
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }

    
}
