using System.Collections.Generic;

namespace MordheimRoster.Models
{
    public abstract class WarbandMember : IWarbandMember
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Experience { get; set; }
        public int GameExperience { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<SpecialRule> SpecialRules { get; set; }
        
        public int M { get; set; }
        public int WS { get; set; }
        public int BS { get; set; }
        public int S { get; set; }
        public int T { get; set; }
        public int W { get; set; }
        public int I { get; set; }
        public int A { get; set; }
        public int Ld { get; set; }

        public int MaxM { get; set; }
        public int MaxWS { get; set; }
        public int MaxBS { get; set; }
        public int MaxS { get; set; }
        public int MaxT { get; set; }
        public int MaxW { get; set; }
        public int MaxI { get; set; }
        public int MaxA { get; set; }
        public int MaxLd { get; set; }

        public abstract int Level { get; }
    }
}