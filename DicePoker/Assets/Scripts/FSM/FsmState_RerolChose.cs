using UnityEngine;

namespace FSM
{
    public class FsmState_RerolChose : FsmState
    {
        private RerolChoseLogic rerolChoseLogic;
        
        public FsmState_RerolChose(Fsm fsm, RerolChoseLogic rcl) : base(fsm)
        {
            rerolChoseLogic = rcl;
        }
        
        public override void Enter()
        {
            Debug.Log("NextState");
        }

        public override void Exit()
        {
            Debug.Log("nextState2");
        }
    }
}