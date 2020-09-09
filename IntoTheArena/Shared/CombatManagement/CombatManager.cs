using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IntoTheArena.Shared.CombatManagement
{
    public class CombatManager : IObservable<CombatRoundResult>
    {
        private List<IObserver<string>> observers;

        public IDisposable Subscribe(IObserver<CombatRoundResult> observer)
        {
            throw new NotImplementedException();
        }
    }
}
