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

        //private int _whitePlayerPoints = 10;
        //private int _blackPlayerPoints = 10;
        public int WhitePlayerPoints 
        { 
            get 
            {
                return 15 + _history.Where(x => x.Result != null).Select(x => x.Result.WhitePlayerAdjustment).Sum();
            }
        }
        public int BlackPlayerPoints
        {
            get
            {
                return 15 + _history.Where(x => x.Result != null).Select(x => x.Result.BlackPlayerAdjustment).Sum();
            }
        }


        Dictionary<string, bool> _animationSemaphore = new Dictionary<string, bool>();

        public Dictionary<string, bool> AnimationSemaphore 
        { 
            get 
            {
                return _animationSemaphore;
            }
        }

        public CombatSession(string Player1Id, string Player2Id) 
        {
            _player1Id = Player1Id;
            _player2Id = Player2Id;

            _animationSemaphore[Player1Id] = false;
            _animationSemaphore[Player2Id] = false;

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
                thisRound.Result = combatResult;
               // _whitePlayerPoints += combatResult.WhitePlayerAdjustment;
               // _blackPlayerPoints += combatResult.BlackPlayerAdjustment;

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
                            //White swings. 
                            //Black swings.

                            Random rng = new Random();
                            bool randomBool = rng.Next(0, 2) > 0;
                            if (randomBool)
                            {
                                //white wins
                                result.WhiteAnimationId = AnimationCommand.AC_COUNTERPARRY;
                                result.BlackAnimationId = AnimationCommand.AC_PARRY;
                                result.WhitePlayerAdjustment = 0;
                                result.BlackPlayerAdjustment = -1;
                                result.Victor = "White";
                                result.Comments = "White and Black both swing. White counter parries. Black takes damage.";
                            }
                            else
                            {
                                //black wins
                                result.WhiteAnimationId = AnimationCommand.AC_PARRY;
                                result.BlackAnimationId = AnimationCommand.AC_COUNTERPARRY;
                                result.WhitePlayerAdjustment = -1;
                                result.BlackPlayerAdjustment = 0;
                                result.Victor = "Black";
                                result.Comments = "White and Black both swing. Black counter parries. White takes damage.";
                            }


                            break;

                        case CombatAction.BLOCK:
                            //White swings. 
                            //Black blocks.

                            result.WhiteAnimationId = AnimationCommand.AC_SWING;
                            result.BlackAnimationId = AnimationCommand.AC_BLOCK;
                            result.WhitePlayerAdjustment = 0;
                            result.BlackPlayerAdjustment = 0;
                            result.Victor = "Black";
                            result.Comments = "White swings. Black blocks.";
                            break;

                        case CombatAction.REST:
                            //White swings. 
                            //Black rests.

                            result.WhiteAnimationId = AnimationCommand.AC_KICK;
                            result.BlackAnimationId = AnimationCommand.AC_GROINED;
                            result.WhitePlayerAdjustment = 0;
                            result.BlackPlayerAdjustment = -2;
                            result.Victor = "White";
                            result.Comments = "Black attempts to heal but white thwarts.";
                            break;
                    }

                    break;
                    
                case CombatAction.BLOCK:
                    switch (thisRound.BlackPlayerMove.Action)
                    {
                        case CombatAction.SWING:
                            //White blocks. 
                            //Black swings.

                            result.WhiteAnimationId = AnimationCommand.AC_BLOCK;
                            result.BlackAnimationId = AnimationCommand.AC_SWING;
                            result.WhitePlayerAdjustment = 0;
                            result.BlackPlayerAdjustment = 0;
                            result.Victor = "White";
                            result.Comments = "Black swings and white blocks.";
                            break;

                        case CombatAction.BLOCK:
                            //White blocks. 
                            //Black swings.

                            result.WhiteAnimationId = AnimationCommand.AC_BLOCK;
                            result.BlackAnimationId = AnimationCommand.AC_BLOCK;
                            result.WhitePlayerAdjustment = 0;
                            result.BlackPlayerAdjustment = 0;
                            result.Victor = "None";
                            result.Comments = "Black white block.";
                            break;

                        case CombatAction.REST:
                            //White blocks. 
                            //Black rests.

                            result.WhiteAnimationId = AnimationCommand.AC_BLOCK;
                            result.BlackAnimationId = AnimationCommand.AC_HEAL;
                            result.WhitePlayerAdjustment = 0;
                            result.BlackPlayerAdjustment = 1;
                            result.Victor = "Black";
                            result.Comments = "Black heals.";
                            break;

                    }

                    break;

                case CombatAction.REST:
                    switch (thisRound.BlackPlayerMove.Action)
                    {
                        case CombatAction.SWING:
                            //White rests. 
                            //Black swings.

                            result.WhiteAnimationId = AnimationCommand.AC_GROINED;
                            result.BlackAnimationId = AnimationCommand.AC_KICK;
                            result.WhitePlayerAdjustment = -2;
                            result.BlackPlayerAdjustment = 0;
                            result.Victor = "Black";
                            result.Comments = "White attempts to heal but is thwarted";
                            break;

                        case CombatAction.BLOCK:
                            //White rests. 
                            //Black swings.

                            result.WhiteAnimationId = AnimationCommand.AC_HEAL;
                            result.BlackAnimationId = AnimationCommand.AC_BLOCK;
                            result.WhitePlayerAdjustment = 1;
                            result.BlackPlayerAdjustment = 0;
                            result.Victor = "White";
                            result.Comments = "White attempts heals";
                            break;

                        case CombatAction.REST:
                            //White rests. 
                            //Black rests.

                            result.WhiteAnimationId = AnimationCommand.AC_HEAL;
                            result.BlackAnimationId = AnimationCommand.AC_HEAL;
                            result.WhitePlayerAdjustment = 1;
                            result.BlackPlayerAdjustment = 1;
                            result.Victor = "None";
                            result.Comments = "White and Black heal";
                            break;

                    }

                    break;

            }

            int wHP = WhitePlayerPoints + result.WhitePlayerAdjustment;
            System.Diagnostics.Debug.WriteLine("wHP: " + wHP);
            result.WhitePlayerTotalHP = wHP;    //WhitePlayerPoints + result.WhitePlayerAdjustment;
            
            int bHP = BlackPlayerPoints + result.BlackPlayerAdjustment; 
            System.Diagnostics.Debug.WriteLine("bHP: " + bHP);
            result.BlackPlayerTotalHP = bHP;    //BlackPlayerPoints + result.BlackPlayerAdjustment;

            return result;
        }

    }
}
