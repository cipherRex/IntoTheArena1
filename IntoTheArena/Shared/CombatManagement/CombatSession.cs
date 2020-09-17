using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntoTheArena.Shared.CombatManagement
{
    public class CombatSession
    {
        private List<CombatRound> _history = new List<CombatRound>();
        private string _player1Id = "";
        private string _player2Id = "";

        public CombatSession(string Player1Id, string Player2Id) 
        {
            _player1Id = Player1Id;
            _player2Id = Player2Id;
            _history.Add(new CombatRound());
        }

        public void AddPlayer1Action(CombatAction Action) 
        {
            _history.Last().Player1Action = Action;
            Resolve();
        }

        public void AddPlayer2Action(CombatAction Action)
        {
            _history.Last().Player2Action = Action;
            Resolve();
        }

        private void Resolve() 
        { 
            if (_history.Last().Player1Action != CombatAction.UNASSIGNED && _history.Last().Player2Action != CombatAction.UNASSIGNED) 
            { 
            
            //resolve and raise event
            
            }
        
        }

    }
}
