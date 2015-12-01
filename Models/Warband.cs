using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.AccessControl;

namespace MordheimRoster.Models
{
    public class Warband
    {
        public int WarbandId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int Gold { get; set; }
        public int Wyrdstone { get; set; }

        public int Raiting { get { return 0; } }

        public virtual ICollection<Equipment> StoredEquipment { get; set; }
        public virtual ICollection<Hero> Heroes { get; set; }
        public virtual ICollection<Henchmen> Henchmens { get; set; }
        public virtual ICollection<HiredSwords> HiredSwords { get; set; }

        public string UserId { get; set; }
    }
}