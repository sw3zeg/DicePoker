using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityTask = System.Threading.Tasks.Task;

public abstract class BoneCast : MonoBehaviour
{
    [SerializeField]
    internal List<Bone> bones = new List<Bone>();
    [SerializeField]
    internal List<Transform> spawnPoints = new List<Transform>();
    [SerializeField]
    internal List<Transform> defaultPoints = new List<Transform>();

    public List<int> dices = new List<int>();
    public int pokerCombination;
    
    public async UnityTask ThrowBones(List<int> indexesChoceDices)
    {
        indexesChoceDices.Sort();
        ThrowBone(indexesChoceDices);
        
        //Ждем пока все кости упадут до конца
        while (BoneDownController.dicesDownCount != indexesChoceDices.Count)
        {
            await UnityTask.Delay(1);
        }
        BoneDownController.dicesDownCount = 0;
        
        AddBones(indexesChoceDices);

        CalcResult();
    }
    
    
    private void CalcResult()
    {
        pokerCombination = CalculatePokerResult(dices);
        MoveToDefaultPoints();
    }

    private void ThrowBone(List<int> indexesChoceDices)
    {
        for (int i = indexesChoceDices.Count - 1; i >= 0; i--)
        {
            int indexToRemove = indexesChoceDices[i];
            if (indexToRemove < dices.Count)
                dices.RemoveAt(indexToRemove);
        }
        
        MoveToSpawnPoints(indexesChoceDices);
        RotateDices(indexesChoceDices);
    }
    
    private void MoveToSpawnPoints(List<int> indexesChoceDices)
    {
        for (int i = 0; i < indexesChoceDices.Count; i++)
            bones[indexesChoceDices[i]].gameObject.transform.position = spawnPoints[indexesChoceDices[i]].position;
    }
    
    private void RotateDices(List<int> indexesChoceDices)
    {
        for (int i = 0; i < indexesChoceDices.Count; i++)
            bones[indexesChoceDices[i]].Rotate();
    }
    
    private void AddBones(List<int> indexesChoceDices)
    {
        for (int i = 0; i < indexesChoceDices.Count; i++)
            dices.Add(bones[indexesChoceDices[i]].boneNum);
    }
    
    private void MoveToDefaultPoints()
    {
        for (int i = 0; i < 5; i++)
            bones[i].gameObject.transform.position = defaultPoints[i].position;
    }
    
    
    public static int CalculatePokerResult(List<int> diceResults)
    {
        if (diceResults.Count != 5)
        {
            throw new ArgumentException("Список должен содержать 5 элементов");
        }

        // Сортируем результаты бросков
        diceResults.Sort();

        // Проверяем наличие комбинаций покера
        if (IsRoyalFlush(diceResults))
        {
            return 100; // Роял флэш
        }
        else if (IsStraightFlush(diceResults))
        {
            return 90; // Стрит флэш
        }
        else if (IsFourOfAKind(diceResults))
        {
            return 80; // Каре
        }
        else if (IsFullHouse(diceResults))
        {
            return 70; // Фулл хаус
        }
        else if (IsFlush(diceResults))
        {
            return 60; // Флэш
        }
        else if (IsStraight(diceResults))
        {
            return 50; // Стрит
        }
        else if (IsThreeOfAKind(diceResults))
        {
            return 40; // Тройка
        }
        else if (IsTwoPair(diceResults))
        {
            return 30; // Две пары
        }
        else if (IsOnePair(diceResults))
        {
            return 20; // Одна пара
        }
        else
        {
            return 10; // Ничего из вышеперечисленного
        }
    }

    // Методы проверки комбинаций покера

    private static bool IsRoyalFlush(List<int> diceResults)
    {
        return diceResults.SequenceEqual(new List<int> { 1, 10, 11, 12, 13 });
    }

    private static bool IsStraightFlush(List<int> diceResults)
    {
        return IsStraight(diceResults) && IsFlush(diceResults);
    }

    private static bool IsFourOfAKind(List<int> diceResults)
    {
        return diceResults.GroupBy(x => x).Any(g => g.Count() == 4);
    }

    private static bool IsFullHouse(List<int> diceResults)
    {
        return diceResults.GroupBy(x => x).Select(g => g.Count()).OrderByDescending(x => x).SequenceEqual(new List<int> { 3, 2 });
    }

    private static bool IsFlush(List<int> diceResults)
    {
        return diceResults.Distinct().Count() == 1;
    }

    private static bool IsStraight(List<int> diceResults)
    {
        for (int i = 0; i < diceResults.Count - 1; i++)
        {
            if (diceResults[i] + 1 != diceResults[i + 1])
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsThreeOfAKind(List<int> diceResults)
    {
        return diceResults.GroupBy(x => x).Any(g => g.Count() == 3);
    }

    private static bool IsTwoPair(List<int> diceResults)
    {
        return diceResults.GroupBy(x => x).Where(g => g.Count() == 2).Count() == 2;
    }

    private static bool IsOnePair(List<int> diceResults)
    {
        return diceResults.GroupBy(x => x).Any(g => g.Count() == 2);
    }
}
