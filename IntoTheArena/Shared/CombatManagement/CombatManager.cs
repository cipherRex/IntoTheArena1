using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IntoTheArena.Shared.CombatManagement
{
    public class CombatManager : IObservable<CombatRoundResult>
    {
        private List<IObserver<string>> observers;

        private Dictionary<string,CombatSession> _combatSessions = new Dictionary<string, CombatSession>();

        public IDisposable Subscribe(IObserver<CombatRoundResult> observer)
        {
            throw new NotImplementedException();
        }

        public string AddCombatSession(CombatSession combatSession) 
        {
            string newSessionId = Guid.NewGuid().ToString();
            _combatSessions[newSessionId] = combatSession;
            return newSessionId;
        }

        public Dictionary<string, CombatSession> Sessions 
        { 
            get { return _combatSessions; }
        }

    }
}
