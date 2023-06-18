using FSM;
using UnityEngine;

public class FsmLogic : MonoBehaviour
{
    [SerializeField]
    private ResultsMenuLogic resultsMenuLogic;
    [SerializeField]
    private StartMenuLogic startMenuLogic;
    [SerializeField]
    private InGameLogic inGameLogic;
    [SerializeField]
    private RerolChoseLogic rerolChoseLogic;
    [SerializeField]
    private RerollLogic rerollLogic;

    
    
    private Fsm fsm = new Fsm();

    private void Awake()
    {
        fsm.AddState("StartMenu",new FsmState_StartMenu(fsm, startMenuLogic));
        fsm.AddState("Game",new FsmState_InGame(fsm, inGameLogic));
        fsm.AddState("ResultMenu",new FsmState_ResultsMenu(fsm, resultsMenuLogic));
        fsm.AddState("RerollChoce",new FsmState_RerolChose(fsm, rerolChoseLogic));
        fsm.AddState("Reroll",new FsmState_Reroll(fsm, rerollLogic));
        fsm.Initialize("StartMenu");
    }

    public void _SetGameState(string stateName)
    {
        fsm.SetState(stateName);
    }
}
