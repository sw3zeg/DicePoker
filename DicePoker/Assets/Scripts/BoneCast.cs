using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BoneCast : MonoBehaviour
{
    [SerializeField]
    private List<Bone> bones = new List<Bone>();
    [SerializeField]
    private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField]
    private List<Transform> defaultPoints = new List<Transform>();

    private List<int> dice = new List<int>();
    public PokerHand hand;

    private void Start()
    {
        MoveToDefaultPoints();
    }

    public void Cast()
    {
        StartCoroutine(IBoneCast());
    }

    private IEnumerator IBoneCast()
    {
        dice = new List<int>();
        CastBone();
        yield return new WaitForSeconds(4);
        AddNums();
        Calc();
    }

    private void CastBone()
    {
        MoveToSpawnPoints();
        Rotate();
    }

    private void Calc()
    {
        hand = CalculatePokerHand();
        MoveToDefaultPoints();
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

    public PokerHand CalculatePokerHand()
    {
        var groupedDice = dice.GroupBy(d => d);
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


    private void AddNums()
    {
        for (int i = 0; i < 5; i++)
            dice.Add(bones[i].boneNum);
    }

    private void Rotate()
    {
        for (int i = 0; i < 5; i++)
            bones[i].Rotate();
    }
}
