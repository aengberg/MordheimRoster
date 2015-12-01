using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MordheimRoster.Models
{
    public class HiredSwords : WarbandMember
    {
        public int HiredSwordsId { get; set; }
        public virtual ICollection<Skill> Skills { get; set; } 

        public override int Level
        {
            get { return 0; }
        }

        //public HiredSwords():base()
        //{
        //    Skills = new Collection<Skill>();
        //    Equipment = new Collection<Equipment>();
        //    SpecialRules = new Collection<SpecialRule>();
        //}
    }
}