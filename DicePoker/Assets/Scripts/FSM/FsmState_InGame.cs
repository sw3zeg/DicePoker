public class FsmState_InGame : FsmState
{
    InGameLogic inGameLogic;
    public FsmState_InGame(Fsm fsm, InGameLogic igl) : base(fsm)
    {
        this.inGameLogic = igl;
    }

    public override void Enter()
    {
        inGameLogic.ThrowBones(fsm);
    }

    public override void Exit()
    {
    }
}