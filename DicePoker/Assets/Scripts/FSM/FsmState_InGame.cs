public class FsmState_InGame : FsmState
{
    private InGameLogic inGameLogic;
    public FsmState_InGame(Fsm fsm, InGameLogic igl) : base(fsm)
    {
        inGameLogic = igl;
    }

    public override void Enter()
    {
        inGameLogic.ThrowBones(fsm);
    }

    public override void Exit()
    {
    }
}