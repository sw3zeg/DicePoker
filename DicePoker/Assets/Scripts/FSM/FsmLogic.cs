using UnityEngine;

public class FsmLogic : MonoBehaviour
{
    [SerializeField]
    private ResultsMenuLogic resultsMenuLogic;
    [SerializeField]
    private StartMenuLogic startMenuLogic;
    [SerializeField]
    private InGameLogic inGameLogic;

    private Fsm fsm = new Fsm();

    private void Awake()
    {
        fsm.AddState(new FsmState_StartMenu(fsm, startMenuLogic));
        fsm.AddState(new FsmState_InGame(fsm, inGameLogic));
        fsm.AddState(new FsmState_ResultsMenu(fsm, resultsMenuLogic));
        fsm.Initialize();
    }

    public void NextGameState()
    {
        fsm.NextState();
    }
}
