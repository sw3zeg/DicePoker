using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static BoneCast;

public class ResultsMenuLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    PlayerBoneCast player;
    [SerializeField]
    EnemyBoneCast enemy;
    [SerializeField]
    TMP_Text resultTxt;

    public void EnableMenu()
    {
        menu.gameObject.SetActive(true);
        resultTxt.text = DetermineWinner(player.hand, enemy.hand);
    }

    public void DesableMenu()
    {
        menu.gameObject.SetActive(false);
    }

    public static string DetermineWinner(PokerHand hand1, PokerHand hand2)
    {
        if (hand1 > hand2)
        {
            return "You win!!";
        }
        else if (hand2 > hand1)
        {
            return "You lose";
        }
        else
        {
            return "Ничья";
        }
    }
}
