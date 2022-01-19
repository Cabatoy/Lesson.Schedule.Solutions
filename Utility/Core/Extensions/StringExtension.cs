using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Newtonsoft.Json;

namespace Core.Extensions
{
    //TODO: Herhangi bir stringi belirtilen objeye çevirir.
    public static class StringExtension
    {
        public static T ToObject<T>(this string value) where T : class
        {
            
            return string.IsNullOrEmpty(value) ? null : JsonConvert.DeserializeObject<T>(value);
        }

        
    }
}
