using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MordheimRoster.Models
{
    interface IWarbandMember
    {
        string Name { get; set; }
        string Type { get; set; }
        int Experience { get; set; }
        int GameExperience { get; set; }

        ICollection<Equipment> Equipment { get; set; }
        ICollection<SpecialRule> SpecialRules { get; set; }
        
        int M { get; set; }
        int WS { get; set; }
        int BS { get; set; }
        int S { get; set; }
        int T { get; set; }
        int W { get; set; }
        int I { get; set; }
        int A { get; set; }
        int Ld { get; set; }

        int MaxM { get; set; }
        int MaxWS { get; set; }
        int MaxBS { get; set; }
        int MaxS { get; set; }
        int MaxT { get; set; }
        int MaxW { get; set; }
        int MaxI { get; set; }
        int MaxA { get; set; }
        int MaxLd { get; set; }

        int Level { get; }
    }
}
