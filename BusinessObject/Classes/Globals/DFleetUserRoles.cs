using AraneaUtilities.Auth.Roles;

namespace BusinessObject
{
    public class DFleetUserRoles: UserRoles<DFleetUserRoles>, IUserRoles
    {
        public override string Default {get; set;}

        public override string Anonymous { get => RolesMap["Anonymous"]; }
        
        public override string Admin { get => RolesMap["Admin"]; }
       
        public string User { get => RolesMap["User"]; }
        
        public string Guest { get => RolesMap["Guest"]; }
        
        public string System { get => RolesMap["System"]; }
        
        public string Partner { get => RolesMap["Partner"]; }


        protected override void Initialize()
        {
            // nessuna inizializzazione extra json
        }

        /// <summary>
        /// Crea un'istanza VUOTA della classe.
        /// </summary>
        public DFleetUserRoles() : base() { }


        /// <summary>
        /// Crea un'istanza della classe inizialndola con json.
        /// </summary>
        public DFleetUserRoles(string json): base(json)
        {
        }
    }
}
