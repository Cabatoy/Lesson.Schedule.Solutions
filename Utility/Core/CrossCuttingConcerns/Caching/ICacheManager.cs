using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);

        void Add(string key, object data, int duration);

        bool IsAdd(string key); //eklenip eklenmediginin kontrolu
        void Remove(string key);
        void RemoveByPattern(string pattern);// belirli bir oruntuyu cagirip silme gibi
    }
}
