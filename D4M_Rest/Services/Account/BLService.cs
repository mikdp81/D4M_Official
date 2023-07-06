using BusinessLogic;
using DFleetRest.Utility;
using System.Net;

namespace DFleetRest.Services
{
    /// <summary>
    /// Implementa l'interfaccia IAccountBL e deriva dalla classe AccountBL.
    /// </summary>
    public class BLService : ApiAccountBL, IBLService
    {
        /// <summary>
        /// costruttore per i servizi di business logic
        /// </summary>
        public BLService():base()
        {
        }
    }

}