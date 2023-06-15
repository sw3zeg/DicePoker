public class FsmState_StartMenu : FsmState
{
    private StartMenuLogic startMenuLogic;
    public FsmState_StartMenu(Fsm fsm, StartMenuLogic sml) : base(fsm)
    {
        startMenuLogic = sml;
    }

    public override void Enter()
    {
        startMenuLogic.EnableMenu();
    }

    public override void Exit()
    {
        startMenuLogic.DesableMenu();
    }
}