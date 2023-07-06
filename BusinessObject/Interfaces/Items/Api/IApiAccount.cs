using AraneaUtilities.JsonUtilities;
using Newtonsoft.Json;

namespace BusinessObject
{
    [JsonConverter(typeof(JsonBinder<Account, IApiAccount>))]
    public interface IApiAccount : IAccount, IApiTeam
    {
        // L'interfaccia IApiAccount eredita da IAccount e IApiTeam.
        // Non contiene nuovi membri, utilizza quelli ereditati dalle interfacce genitore.
    }
}
