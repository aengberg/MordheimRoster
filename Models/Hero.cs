using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.AccessControl;

namespace MordheimRoster.Models
{
    public class Hero : WarbandMember
    {
        public int HeroId { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Injurie> Injuries { get; set; }

        public override int Level
        {
            get { return 0; }
        }

        //public Hero()
        //{
        //    Equipment = new Collection<Equipment>();
        //    Skills = new Collection<Skill>();
        //    Injuries = new Collection<Injurie>();
        //    SpecialRules = new Collection<SpecialRule>();
            
        //}
    }
}