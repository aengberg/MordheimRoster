using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MordheimRoster.Models
{
    public class Henchmen : WarbandMember
    {
        public int HenchmenId { get; set; }
        public int Number { get; set; }

        public override int Level
        {
            get { return 0; }
        }

        //public Henchmen()
        //{
        //    Equipment = new Collection<Equipment>();
        //    SpecialRules = new Collection<SpecialRule>();

        //}
    }
}