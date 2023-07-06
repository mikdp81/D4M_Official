using AraneaUtilities.JsonUtilities;
using System.Collections.Generic;
using System.Linq;

namespace AraneaUtilities.Auth.Roles
{
    public abstract class UserRoles<T> : JsonEntity<T> where T : UserRoles<T>, IUserRoles
    {

        public abstract string Default { get; set; }
        public abstract string Admin { get; }
        public abstract string Anonymous { get; }

        /// <inheritdoc />
        public Dictionary<string, string> RolesMap { get; set; }


        /// <summary>
        /// Crea un'istanza VUOTA della classe derivata.
        /// </summary>
        public UserRoles() : base() { }


        /// <summary>
        /// Crea un'istanza della classe derivata usando un'entità JSON.
        /// </summary>
        /// <param name="json">L'entità JSON da deserializzare.</param>
        public UserRoles(string json) : base(json) { }


        /// <inheritdoc/>
        public bool IsAdmin(string role)
        {
            return Admin == role;
        }

        /// <inheritdoc/>
        public bool IsDefault(string role)
        {
            return Default == role;
        }

        /// <inheritdoc/>
        public bool IsAnonymous(string role)
        {
            return Anonymous == role;
        }

        /// <inheritdoc/>
        public bool IsValid(string role)
        {
            return RolesMap.ContainsValue(role);
        }

        /// <inheritdoc/>
        public string[] GetValues()
        {
            return RolesMap.Values.ToArray();
        }

        /// <inheritdoc/>
        public string GetRole(string roleKey)
        {
            return RolesMap[roleKey];
        }


    }
}
