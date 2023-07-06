using Castle.Core.Interceptor;
using System;

namespace AraneaUtilities.InterceptingFilters
{
    /// <summary>
    /// Rappresenta una classe che intercetta le chiamate di un oggetto TARGET e applica filtri prima e dopo l'esecuzione.
    /// </summary>
    /// <typeparam name="TO">Il tipo dell'oggetto target.</typeparam>
    public class Interceptor<TO> : IInterceptor where TO : class
    {
        /// <summary>
        /// Ottiene il filtro da applicare prima dell'esecuzione del metodo.
        /// </summary>
        internal IProxyFilter PreFilter { get; private set; }

        /// <summary>
        /// Ottiene il filtro da applicare dopo l'esecuzione del metodo.
        /// </summary>
        internal IProxyFilter PostFilter { get; private set; }

        /// <summary>
        /// Crea una nuova istanza di Interceptor.
        /// </summary>
        /// <param name="preFilter">Il filtro da applicare prima dell'esecuzione del metodo.</param>
        /// <param name="postFilter">Il filtro da applicare dopo l'esecuzione del metodo.</param>
        public Interceptor(IProxyFilter preFilter, IProxyFilter postFilter)
        {
            PreFilter = preFilter;
            PostFilter = postFilter;
        }

        /// <summary>
        /// Intercetta l'invocazione del metodo target e applica i filtri pre e post.
        /// </summary>
        /// <param name="invocation">L'invocazione del metodo.</param>
        public void Intercept(IInvocation invocation)
        {
            // Operazioni da eseguire prima dell'esecuzione del metodo
            if (PreFilter != null && !PreFilter.Execute())
                throw new Exception("Filtro pre-esecuzione: " + PreFilter.GetType().ToString() + " non superato");

            // Esegue il metodo target
            invocation.Proceed();

            // Operazioni da eseguire dopo l'esecuzione del metodo
            if (PostFilter != null && !PostFilter.Execute())
                throw new Exception("Filtro post-esecuzione: " + PostFilter.GetType().ToString() + " non superato");
        }
    }
}
