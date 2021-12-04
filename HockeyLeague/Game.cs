//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HockeyLeague
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            this.Cause_cansel_game = new HashSet<Cause_cansel_game>();
            this.Game_Account_Information = new HashSet<Game_Account_Information>();
        }
    
        public int id { get; set; }
        public Nullable<int> HostTeam { get; set; }
        public Nullable<int> GuestTeam { get; set; }
        public Nullable<decimal> HostTeamScore { get; set; }
        public Nullable<decimal> GuestTeamScore { get; set; }
        public Nullable<System.DateTime> GameData { get; set; }
        public string City { get; set; }
        public Nullable<bool> Match_status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cause_cansel_game> Cause_cansel_game { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Game_Account_Information> Game_Account_Information { get; set; }
        public virtual Team Team { get; set; }
        public virtual Team Team1 { get; set; }
        public virtual TeamTwo TeamTwo { get; set; }
    }
}
