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

        private int _whitePlayerPoints = 10;
        private int _blackPlayerPoints = 10;

        public CombatSession(string Player1Id, string Player2Id) 
        {
            _player1Id = Player1Id;
            _player2Id = Player2Id;
            _history.Add(new CombatRound());
        }

        public string Player1Id { get { return _player1Id; } }
        public string Player2Id { get { return _player2Id; } }

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

            if (_player1Id == Move.PlayerId) 
            {
                thisRound.WhitePlayerMove = Move;
            } else 
            {
                thisRound.BlackPlayerMove = Move;
            }
            
            if (thisRound.WhitePlayerMove != null && thisRound.BlackPlayerMove != null) 
            {
                CombatResult combatResult = resolveRound(thisRound);
                _whitePlayerPoints += combatResult.WhitePlayerAdjustment;
                _blackPlayerPoints += combatResult.BlackPlayerAdjustment;

                _history.Add(new CombatRound());

                return combatResult;
            }
            else { return null; }
        }

        private CombatResult resolveRound(CombatRound thisRound) 
        {
            CombatResult result = new CombatResult();

            switch (thisRound.WhitePlayerMove.Action) 
            {
                case CombatAction.SWING:
                    switch (thisRound.BlackPlayerMove.Action)
                    {
                        case CombatAction.SWING:
                            result.AnimationId = 1;
                            result.WhitePlayerAdjustment = -1;
                            result.BlackPlayerAdjustment = -1;
                            result.Victor = "None";
                            result.Comments = "White and Black both swing. Both receive damage";
                            break;

                        case CombatAction.BLOCK:
                            result.AnimationId = 2;
                            result.WhitePlayerAdjustment = 0;
                            result.BlackPlayerAdjustment = 0;
                            result.Victor = "Black";
                            result.Comments = "White swings and Black blocks. Black wins";
                            break;

                        case CombatAction.REST:
                            result.AnimationId = 3;
                            result.WhitePlayerAdjustment = 0;
                            result.BlackPlayerAdjustment = -1;
                            result.Victor = "White";
                            result.Comments = "White swings and Black attempts to rest. Black loses a point";
                            break;

                    }

                    break;

                case CombatAction.BLOCK:
                    switch (thisRound.BlackPlayerMove.Action)
                    {
                        case CombatAction.SWING:
                            result.AnimationId = 4;
                            result.WhitePlayerAdjustment = 0;
                            result.BlackPlayerAdjustment = 0;
                            result.Victor = "White";
                            result.Comments = "White blocks and Black swings. White wins";
                            break;

                        case CombatAction.BLOCK:
                            result.AnimationId = 5;
                            result.WhitePlayerAdjustment = 0;
                            result.BlackPlayerAdjustment = 0;
                            result.Victor = "None";
                            result.Comments = "White blocks and Black swings. Neither wins";
                            break;

                        case CombatAction.REST:
                            result.AnimationId = 6;
                            result.WhitePlayerAdjustment = 0;
                            result.BlackPlayerAdjustment = +1;
                            result.Victor = "Black";
                            result.Comments = "White blocks and Black rests. Black gains a point";
                            break;

                    }


                    break;

                case CombatAction.REST:
                    switch (thisRound.BlackPlayerMove.Action)
                    {
                        case CombatAction.SWING:
                            result.AnimationId = 7;
                            result.WhitePlayerAdjustment = -1;
                            result.BlackPlayerAdjustment = 0;
                            result.Victor = "Black";
                            result.Comments = "White attempts to rest but Black swings. White loses a point";
                            break;

                        case CombatAction.BLOCK:
                            result.AnimationId = 8;
                            result.WhitePlayerAdjustment = +1;
                            result.BlackPlayerAdjustment = 0;
                            result.Victor = "White";
                            result.Comments = "White rests as Black blocks. White gains point";
                            break;

                        case CombatAction.REST:
                            result.AnimationId = 9;
                            result.WhitePlayerAdjustment = +1;
                            result.BlackPlayerAdjustment = +1;
                            result.Victor = "None";
                            result.Comments = "White and Black rest. Both gain a point";
                            break;

                    }


                    break;


            }

            return result;
        }

    }
}
