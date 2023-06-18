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

    private List<int> dices = new List<int>();
    public PokerHand hand;
    
    public async UnityTask ThrowBones()
    {
        ThrowBone();
        
        //Ждем пока все кости упадут до конца
        while (BoneDownController.dicesDownCount != 5)
            await UnityTask.Delay(1);
        BoneDownController.dicesDownCount = 0;

        AddBones();
        CalcResult();
    }

    private void ThrowBone()
    {
        dices = new List<int>();
        MoveToSpawnPoints();
        RotateDices();
    }

    private void CalcResult()
    {
        hand = CalculatePokerHand();
        MoveToDefaultPoints();
    }

    private void MoveToDefaultPoints()
    {
        for (int i = 0; i < 5; i++)
            bones[i].gameObject.transform.position = defaultPoints[i].position;
    }

    private void MoveToSpawnPoints()
    {
        for (int i = 0; i < 5; i++)
            bones[i].gameObject.transform.position = spawnPoints[i].position;
    }

    private void AddBones()
    {
        for (int i = 0; i < 5; i++)
            dices.Add(bones[i].boneNum);
    }

    private void RotateDices()
    {
        for (int i = 0; i < 5; i++)
            bones[i].Rotate();
    }


    public PokerHand CalculatePokerHand()
    {
        var groupedDice = dices.GroupBy(d => d);
        var counts = groupedDice.Select(g => g.Count()).ToList();
        counts.Sort();

        if (counts.SequenceEqual(new List<int> { 1, 1, 1, 1, 1 }))
        {
            return PokerHand.None;
        }
        else if (counts.SequenceEqual(new List<int> { 1, 1, 1, 2 }))
        {
            return PokerHand.OnePair;
        }
        else if (counts.SequenceEqual(new List<int> { 1, 2, 2 }))
        {
            return PokerHand.TwoPairs;
        }
        else if (counts.SequenceEqual(new List<int> { 1, 1, 3 }))
        {
            return PokerHand.ThreeOfAKind;
        }
        else if (counts.SequenceEqual(new List<int> { 2, 3 }))
        {
            return PokerHand.FullHouse;
        }
        else if (counts.SequenceEqual(new List<int> { 1, 4 }))
        {
            return PokerHand.FourOfAKind;
        }
        else if (counts.SequenceEqual(new List<int> { 5 }))
        {
            return PokerHand.FiveOfAKind;
        }

        throw new ArgumentException("Invalid dice combination.");
    }

    public enum PokerHand
    {
        None,
        OnePair,
        TwoPairs,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind
    }
}
