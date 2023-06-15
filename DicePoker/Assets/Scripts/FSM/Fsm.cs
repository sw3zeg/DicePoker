using System;
using System.Collections.Generic;

public class Fsm
{
    private FsmState currentState;
    private int currentStateIndex = -1;
    private Dictionary<int, FsmState> states = new Dictionary<int, FsmState>();

    public void Initialize()
    {
        SetState(0);
    }

    public void AddState(FsmState state)
    {
        if (states.ContainsValue(state) == false)
            states.Add(states.Count, state);
        else
            throw new Exception("Invalid state exception");
    }

    public void NextState()
    {
        if (states.Count <= 1)
            return;
        int nextStateIndex = (currentStateIndex + 1) % states.Count;
        SetState(nextStateIndex);
    }

    private void SetState(int stateIndex)
    {
        if (stateIndex == currentStateIndex)
            return;

        if (states.TryGetValue(stateIndex, out FsmState newState))
        {
            currentState?.Exit();
            currentState = newState;
            currentStateIndex = stateIndex;
            currentState?.Enter();
        }
        else
            throw new Exception("No such state");
    }
}