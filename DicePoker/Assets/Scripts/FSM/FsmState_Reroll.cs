using UnityEngine;

namespace FSM
{
    public class FsmState_Reroll : FsmState
    {
        private RerollLogic rerollLogic;
        
        public FsmState_Reroll(Fsm fsm, RerollLogic rl) : base(fsm)
        {
            rerollLogic = rl;
        }
        
        public override void Enter()
        {
            rerollLogic.ThrowBones(fsm);
        }

        public override void Exit()
        {
            
        }
    }
}