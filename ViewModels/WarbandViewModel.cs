using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MordheimRoster.Models;

namespace MordheimRoster.ViewModels
{
    public class WarbandViewModel
    {
        public Warband Warband { get; set; }

        public int WarbandId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int Gold { get; set; }
        public int Wyrdstone { get; set; }

        public int Raiting { get { return 0; } }

        public ICollection<Equipment> StoredEquipment { get; protected set; }
        public ICollection<Hero> Heroes { get; protected set; }
        public ICollection<Henchmen> Henchmens { get; protected set; }
        public ICollection<HiredSwords> HiredSwords { get; protected set; }

        public Hero Leader { get; set; }

        public string UserId { get; set; }

        public WarbandViewModel(Warband warband)
        {
            Warband = warband;
            WarbandId = warband.WarbandId;
            Name = warband.Name;
            Type = warband.Type;
            Gold = warband.Gold;
            Wyrdstone = warband.Wyrdstone;
            UserId = warband.UserId;
            StoredEquipment = warband.StoredEquipment;
            Heroes = warband.Heroes;
            Henchmens = warband.Henchmens;
            HiredSwords = warband.HiredSwords;
        }
    }
}