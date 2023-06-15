public class FsmState_ResultsMenu : FsmState
{
    ResultsMenuLogic resultsMenuLogic;

    public FsmState_ResultsMenu(Fsm fsm, ResultsMenuLogic rml) : base(fsm)
    {
        resultsMenuLogic = rml;
    }

    public override void Enter()
    {
        resultsMenuLogic.EnableMenu();
    }

    public override void Exit()
    {
        resultsMenuLogic.DesableMenu();
    }
}