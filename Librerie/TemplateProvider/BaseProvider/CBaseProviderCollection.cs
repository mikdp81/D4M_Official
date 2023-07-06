using System.Configuration.Provider;

namespace Provider
{
    public class BaseProviderCollection<T> : ProviderCollection where T : BaseProvider
    {
        public T this[string name]
        {
            get
            {
                return (T)base[name];
            }
        }
    }
}