using System;
using System.Collections.Generic;
using System.Linq;
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
        await enemy.ThrowBones(GetUnnecessaryIndexesForSameNumbers(enemy.dices));
        await UnityTask.Delay(TimeSpan.FromSeconds(1));
        fsm.SetState("ResultMenu");
    }
     
    
    public static List<int> GetUnnecessaryIndexesForSameNumbers(List<int> diceResults)
    {
        if (diceResults.Count != 5)
        {
            throw new ArgumentException("Список должен содержать 5 элементов");
        }

        List<int> unnecessaryIndexes = new List<int>();

        var groupedResults = diceResults.Select((value, index) => new { Value = value, Index = index })
            .GroupBy(x => x.Value)
            .ToList();

        foreach (var group in groupedResults)
        {
            int count = group.Count();

            if (count > 1)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    unnecessaryIndexes.Add(group.ElementAt(i).Index);
                }
            }
        }

        return unnecessaryIndexes;
    }
}