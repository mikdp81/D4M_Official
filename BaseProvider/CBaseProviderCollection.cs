using System.Configuration.Provider;

namespace BaseProvider
{
    public class BaseProviderCollection<T> : ProviderCollection where T : BaseProvider
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public T this[string name]
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            get
            {
                return (T)base[name];
            }
        }
    }
}