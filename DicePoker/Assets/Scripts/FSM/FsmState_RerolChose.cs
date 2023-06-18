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
            rerolChoseLogic.EnableMenu();
        }

        public override void Exit()
        {
            rerolChoseLogic.DesableMenu();
        }
    }
}