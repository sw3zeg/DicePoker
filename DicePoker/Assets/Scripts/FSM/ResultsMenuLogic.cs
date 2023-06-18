using TMPro;
using UnityEngine;
using static BoneCast;

public class ResultsMenuLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private PlayerBoneCast player;
    [SerializeField]
    private EnemyBoneCast enemy;
    [SerializeField]
    private TMP_Text resultTxt;

    public void EnableMenu()
    {
        menu.gameObject.SetActive(true);
        resultTxt.text = DetermineWinner(player.pokerCombination, enemy.pokerCombination);
    }

    public void DesableMenu()
    {
        menu.gameObject.SetActive(false);
    }

    public string DetermineWinner(int player, int enemy)
    {
        if (player > enemy)
            return "You win!! :D";
        else if (player < enemy)
            return "You lose :(";
        else
            return "Paritet";
    }
}
