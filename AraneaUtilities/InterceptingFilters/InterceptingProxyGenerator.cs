using ProxyGenerator = Castle.DynamicProxy.ProxyGenerator;

namespace AraneaUtilities.InterceptingFilters
{
    /// <summary>
    /// Rappresenta una classe di proxy di intercettazione.
    /// </summary>
    /// <typeparam name="TO">Il tipo dell'oggetto target.</typeparam>
    /// <typeparam name="ITP">Il tipo dell'interfaccia del proxy.</typeparam>
    public class InterceptingProxyGenerator<TO, ITP> : IInterceptingProxyGenerator<ITP>
        where ITP : class
        where TO : class, ITP
    {
        private static InterceptingProxyGenerator<TO, ITP> _interceptingProxy;
        private static readonly ProxyGenerator _proxyGenerator = new ProxyGenerator();
        private Interceptor<TO> _interceptor;
        private TO _targetObject;
        private ITP _interfaceToProxy;

        /// <summary>
        /// Crea una nuova istanza di InterceptingProxyGenerator.
        /// </summary>
        /// <param name="preFilter">Il filtro di pre-elaborazione.</param>
        /// <param name="postFilter">Il filtro di post-elaborazione.</param>
        /// <param name="targetObject">L'oggetto target su cui agisce il filtro.</param>
        private InterceptingProxyGenerator(IProxyFilter preFilter, IProxyFilter postFilter,
            TO targetObject, ITP interfaceToProxy)
        {
            _targetObject = targetObject;
            _interfaceToProxy = interfaceToProxy;
            _interceptor = new Interceptor<TO>(preFilter, postFilter);
        }

        /// <summary>
        /// Restituisce un'istanza di InterceptingProxyGenerator.
        /// </summary>
        /// <param name="preFilter">Il filtro di pre-elaborazione.</param>
        /// <param name="postFilter">Il filtro di post-elaborazione.</param>
        /// <param name="targetObject">L'oggetto target su cui agisce il filtro.</param>
        /// <returns>Un'istanza di InterceptingProxyGenerator.</returns>
        public static IInterceptingProxyGenerator<ITP> GetInstance(IProxyFilter preFilter, IProxyFilter postFilter,
            TO targetObject)
        {
            if (_interceptingProxy == null)
                _interceptingProxy = new InterceptingProxyGenerator<TO, ITP>(preFilter, postFilter, targetObject, targetObject);
            else
            {
                _interceptingProxy._targetObject = targetObject;
                _interceptingProxy._interfaceToProxy = targetObject;
                _interceptingProxy._interceptor = new Interceptor<TO>(preFilter, postFilter);
            }

            return _interceptingProxy;
        }

        /// <summary>
        /// Crea una nuova istanza di InterceptingProxyGenerator.
        /// </summary>
        /// <param name="preFilter">Il filtro di pre-elaborazione.</param>
        /// <param name="postFilter">Il filtro di post-elaborazione.</param>
        /// <param name="targetObject">L'oggetto target su cui agisce il filtro.</param>
        /// <returns>Un'istanza di InterceptingProxyGenerator.</returns>
        public static IInterceptingProxyGenerator<ITP> NewInstance(IProxyFilter preFilter, IProxyFilter postFilter,
            TO targetObject)
        {
            return new InterceptingProxyGenerator<TO, ITP>(preFilter, postFilter, targetObject, targetObject);
        }


        /// <summary>
        /// Aggiunge i filtri specificati all'oggetto target e restituisce il riferimento di una interfaccia.
        /// </summary>
        /// <param name="interfaceToProxy">L'interfaccia del proxy.</param>
        /// <returns>Un'interfaccia che punta all'oggetto target con i filtri aggiunti.</returns>
        public ITP GenerateProxy()
        {
            return _proxyGenerator.CreateInterfaceProxyWithTarget(_interfaceToProxy, _interceptor);
        }

        /// <inheritdoc cref="IInterceptingProxyGenerator{ITP}.GenerateProxy"/>
        ITP IInterceptingProxyGenerator<ITP>.GenerateProxy()
        {
            return GenerateProxy();
        }
    }
}
