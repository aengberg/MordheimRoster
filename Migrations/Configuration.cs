

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MordheimRoster.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        bool AddUserAndRole(ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            
            rm.Create(new IdentityRole("canDelete"));
            rm.Create(new IdentityRole("canRead"));
            rm.Create(new IdentityRole("canCreate"));            
            rm.Create(new IdentityRole("canEdit"));

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            
            var user = new ApplicationUser()
            {
                UserName = "pja.engberg@gmail.com",
            };

            ir = um.Create(user, "nissepisse");
            
            if (ir.Succeeded == false)
                return ir.Succeeded;

            um.AddToRole(user.Id, "canDelete");
            um.AddToRole(user.Id, "canRead");
            um.AddToRole(user.Id, "canCreate");
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        protected override void Seed(ApplicationDbContext context)
        {    
            AddUserAndRole(context);

            context.Contacts.AddOrUpdate(p => p.Name,
                new Contact
                {
                    Name = "Andreas Engberg",
                    Address = "",
                    City = "Göteborg",
                    State = "",
                    Zip = "",
                    Email = "",
                });

            var equipments = new List<Equipment> {
                new Equipment() {Name = "Dagger"},
                new Equipment() {Name = "Sword"},
                new Equipment() {Name = "Axe"},
                new Equipment() {Name = "Hammer"},
                new Equipment() {Name = "Pistol"},
                new Equipment() {Name = "Bow"}};

            equipments.ForEach(s => context.Equipments.AddOrUpdate(s));
            context.SaveChanges();

            var skills = new List<Skill> {new Skill {Name = "Quick Shot"}};        
            skills.ForEach(s=> context.Skills.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var specialrules = new List<SpecialRule>{new SpecialRule {Name = "Leader"}};
            specialrules.ForEach(s => context.SpecialRules.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var injuries = new List<Injurie>{new Injurie {Name = "Leg wound"}};
            injuries.ForEach(s => context.Injuries.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var heroes = new List<Hero> {new Hero
            {
                Name = "Sunny",
                Type = "Vampire",
                M = 6,
                WS = 5,
                BS = 5,
                I = 8,
                Ld = 9,
                W = 0,
                S = 4,
                T = 4,
                A = 2,
                Skills = new Collection<Skill> {context.Skills.FirstOrDefault(p => p.Name == "Quick Shot")},
                Equipment = new Collection<Equipment> {context.Equipments.FirstOrDefault(p => p.Name == "Axe")},
                SpecialRules = new Collection<SpecialRule> {context.SpecialRules.FirstOrDefault(p => p.Name == "Leader")},
                Injuries = new Collection<Injurie> {context.Injuries.FirstOrDefault(p => p.Name == "Leg wound")}
            },new Hero
            {
                Name = "Verna",
                Type = "Matriarch",
                M = 5,
                WS = 4,
                BS = 4,
                I = 8,
                Ld = 9,
                W = 0,
                S = 3,
                T = 3,
                A = 1,
                Skills = new Collection<Skill> { context.Skills.FirstOrDefault(p => p.Name == "Quick Shot") },
                Equipment = new Collection<Equipment> { context.Equipments.FirstOrDefault(p => p.Name == "Hammer") },
                SpecialRules = new Collection<SpecialRule> { context.SpecialRules.FirstOrDefault(p => p.Name == "Leader") },
                Injuries = new Collection<Injurie> { context.Injuries.FirstOrDefault(p => p.Name == "Leg wound") }
            }};

            heroes.ForEach(s => context.Heroes.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var warbands = new List<Warband> {new Warband
            {
                Name = "Train of the Undead",
                Type = "Undead",
                Heroes = new Collection<Hero> { context.Heroes.FirstOrDefault(p => p.Name.Equals("Sunny")) }
            },new Warband
            {
                Name = "Sisters of the Light",
                Type = "Sisters of Sigmar",
                Heroes = new Collection<Hero> { context.Heroes.FirstOrDefault(p => p.Name.Equals("Verna")) }
            }};
            warbands.ForEach(s => context.Warbands.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}
