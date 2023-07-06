using AraneaUtilities;
using System;
using System.Web;
using System.Globalization;

namespace BusinessObject
{
    /// <summary>
    /// Rappresenta un'eccezione personalizzata per DFleet.
    /// Implementa l'interfaccia ICustomException.
    /// </summary>
    [Serializable]
    public class DFleetException : ICustomException
    {
        private static string _stringEmpty = string.Empty;

        private DateTime _datauserins;
        private int _iduserins;
        private string _Data = _stringEmpty;
        private string _HelpLink = _stringEmpty;
        private string _HResult = _stringEmpty;
        private string _InnerException = _stringEmpty;
        private string _Message = _stringEmpty;
        private string _Source = _stringEmpty;
        private string _StackTrace = _stringEmpty;
        private string _TargetSite = _stringEmpty;

        /// <summary>
        /// Ottiene o imposta il link di aiuto per l'eccezione.
        /// </summary>
        public string HelpLink { get => _HelpLink; set => _HelpLink = value; }

        /// <summary>
        /// Ottiene o imposta i dati personalizzati per l'eccezione.
        /// </summary>
        public string Data { get => _Data; set => _Data = value; }

        /// <summary>
        /// Ottiene o imposta il codice HResult per l'eccezione.
        /// </summary>
        public string HResult { get => _HResult; set => _HResult = value; }

        /// <summary>
        /// Ottiene o imposta l'eccezione interna per l'eccezione corrente.
        /// </summary>
        public string InnerException { get => _InnerException; set => _InnerException = value; }

        /// <summary>
        /// Ottiene o imposta il messaggio di errore per l'eccezione.
        /// </summary>
        public string Message { get => _Message; set => _Message = value; }

        /// <summary>
        /// Ottiene o imposta il nome dell'oggetto o dell'applicazione che ha generato l'eccezione.
        /// </summary>
        public string Source { get => _Source; set => _Source = value; }

        /// <summary>
        /// Ottiene o imposta la traccia dello stack per l'eccezione.
        /// </summary>
        public string StackTrace { get => _StackTrace; set => _StackTrace = value; }

        /// <summary>
        /// Ottiene o imposta il metodo che ha generato l'eccezione.
        /// </summary>
        public string TargetSite { get => _TargetSite; set => _TargetSite = value; }

        /// <summary>
        /// Ottiene o imposta l'ID dell'utente che ha generato l'eccezione.
        /// </summary>
        public int Iduserins { get => _iduserins; set => _iduserins = value; }

        /// <summary>
        /// Ottiene o imposta la data in cui è stata generata l'eccezione.
        /// </summary>
        public DateTime DataUserins { get => _datauserins; set => _datauserins = value; }

        /// <summary>
        /// Inizializza una nuova istanza della classe DFleetException con un'eccezione specificata.
        /// </summary>
        /// <param name="e">L'eccezione da utilizzare per inizializzare l'istanza.</param>
        public DFleetException(Exception e)
        {
            if (e != null)
            {
                // Raccolta dati
                if (e.Data != null)
                    Data = e.Data.ToString();
                if (e.HelpLink != null)
                    HelpLink = e.HelpLink.ToString(CultureInfo.CurrentCulture);
                HResult = e.HResult.ToString(CultureInfo.CurrentCulture);
                if (e.InnerException != null)
                    InnerException = e.InnerException.ToString();
                if (e.Message != null)
                    Message = e.Message;
                if (e.Source != null)
                    Source = e.Source.ToString(CultureInfo.CurrentCulture);
                if (e.StackTrace != null)
                    StackTrace = e.StackTrace.ToString(CultureInfo.CurrentCulture);
                if (e.TargetSite != null)
                    TargetSite = e.TargetSite.ToString();
                Iduserins = UserID();
                DataUserins = DateTime.Now;
            }
        }

        /// <summary>
        /// Ottiene l'ID dell'utente corrente.
        /// </summary>
        /// <returns>L'ID dell'utente corrente o 0 se non disponibile.</returns>
        public int UserID()
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["UserID"] != null)
                return (int)HttpContext.Current.Session["UserID"];
            else
                return 0;
        }

        /// <summary>
        /// Restituisce il messaggio di errore dell'eccezione.
        /// </summary>
        /// <returns>Il messaggio di errore dell'eccezione.</returns>
        public string Response()
        {
            return Message;
        }
    }
}
