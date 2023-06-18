using System;
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
        await player.ThrowBones();
        await UnityTask.Delay(TimeSpan.FromSeconds(1.5));
        await enemy.ThrowBones();
        await UnityTask.Delay(TimeSpan.FromSeconds(1));
        fsm.NextState();
    }
    
}
