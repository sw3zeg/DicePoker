using System;
using System.Collections.Generic;
using UnityEngine;
using UnityTask = System.Threading.Tasks.Task;

public class RerollLogic : MonoBehaviour
{
    [SerializeField]
    PlayerBoneCast player;
    [SerializeField]
    EnemyBoneCast enemy;
    
    public async UnityTask ThrowBones(Fsm fsm)
    {
        await UnityTask.Delay(TimeSpan.FromSeconds(1));
        await player.ThrowBones(SelectionController.selectedDices);
        SelectionController.selectedDices = new List<int>();
        await UnityTask.Delay(TimeSpan.FromSeconds(1.5));
        await enemy.ThrowBones(new List<int>(){3,4});
        await UnityTask.Delay(TimeSpan.FromSeconds(1));
        fsm.SetState("ResultMenu");
    }
        
}