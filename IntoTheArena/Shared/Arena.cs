using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntoTheArena.Shared
{
    public class Arena
    {
         List<Fighter> _fighters = new List<Fighter>();


        public Arena() 
        {
            _fighters.Add(new Fighter() {id = Guid.NewGuid().ToString(), Picture = "fig4.png", Name="Grok" });
            _fighters.Add(new Fighter() { id = Guid.NewGuid().ToString(), Picture = "fig1.png", Name = "Otik" });

            _fighters.Add(new Fighter() { id = Guid.NewGuid().ToString(), Picture = "fig2.png", Name = "Juan" });
            _fighters.Add(new Fighter() { id = Guid.NewGuid().ToString(), Picture = "fig3.png", Name = "Norge" });

            _fighters.Add(new Fighter() { id = Guid.NewGuid().ToString(), Picture = "fig4.png", Name = "Randy" });
            _fighters.Add(new Fighter() { id = Guid.NewGuid().ToString(), Picture = "fig1.png", Name = "Ootpik" });


        }

        public List<Fighter> Fighters() 
        {
            return _fighters;

        }

        public void AddFighter (Fighter fighter) 
        {
            _fighters.Add(fighter);
        }

        public void RemoveFighter(Fighter fighter)
        {
            _fighters.Remove(fighter);
        }

    }
}
