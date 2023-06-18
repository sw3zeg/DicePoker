using System;
using System.Collections.Generic;
using UnityEngine;
using UnityTask = System.Threading.Tasks.Task;

public class InGameLogic : MonoBehaviour
{
    [SerializeField]
    PlayerBoneCast player;
    [SerializeField]
    EnemyBoneCast enemy;
    
    public async UnityTask ThrowBones(Fsm fsm)
    {
        await UnityTask.Delay(TimeSpan.FromSeconds(1));
        await player.ThrowBones(new List<int>(){0,1,2,3,4} );
        await UnityTask.Delay(TimeSpan.FromSeconds(1.5));
        await enemy.ThrowBones(new List<int>(){0,1,2,3,4} );
        await UnityTask.Delay(TimeSpan.FromSeconds(1));
        fsm.SetState("RerollChoce");
    }
    
}
