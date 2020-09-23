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



        //public void AddPlayer1Action(CombatAction Action) 
        //{
        //    _history.Last().Player1Action = Action;
        //    Resolve();
        //}

        //public void AddPlayer2Action(CombatAction Action)
        //{
        //    _history.Last().Player2Action = Action;
        //    Resolve();
        //}

        //private void Resolve() 
        //{ 
        //    if (_history.Last().Player1Action != CombatAction.UNASSIGNED && _history.Last().Player2Action != CombatAction.UNASSIGNED) 
        //    { 

        //    //resolve and raise event

        //    }

        //}

        public CombatResult Resolve(CombatMove Move) 
        {

            CombatRound thisRound =  _history.Last();

            if (_player1Id == Move.FighterId) 
            {
                thisRound.Player1Action = Move;
            } else 
            {
                thisRound.Player2Action = Move;
            }
            
            if (thisRound.Player1Action != null && thisRound.Player2Action != null) 
            {
                return resolveRound(thisRound);
            }
            else { return null; }
        }

        private CombatResult resolveRound(CombatRound thisRound) 
        {
            CombatResult result = new CombatResult();

            switch (thisRound.Player1Action.Action) 
            {
                case CombatAction.SWING:
                    switch (thisRound.Player2Action.Action)
                    {
                        case CombatAction.SWING:
                            result.AnimationId = 1;
                            break;

                        case CombatAction.BLOCK:
                            result.AnimationId = 2;
                            break;

                        case CombatAction.REST:
                            result.AnimationId = 3;
                            break;

                    }

                    break;

                case CombatAction.BLOCK:
                    switch (thisRound.Player2Action.Action)
                    {
                        case CombatAction.SWING:
                            result.AnimationId = 4;
                            break;

                        case CombatAction.BLOCK:
                            result.AnimationId = 5;
                            break;

                        case CombatAction.REST:
                            result.AnimationId = 6;
                            break;

                    }


                    break;

                case CombatAction.REST:
                    switch (thisRound.Player2Action.Action)
                    {
                        case CombatAction.SWING:
                            result.AnimationId = 7;
                            break;

                        case CombatAction.BLOCK:
                            result.AnimationId = 8;
                            break;

                        case CombatAction.REST:
                            result.AnimationId = 9;
                            break;

                    }


                    break;


            }

            return result;
        }

    }
}
