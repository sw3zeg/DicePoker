using System.Collections;
using UnityEngine;

public class InGameLogic : MonoBehaviour
{
    [SerializeField]
    PlayerBoneCast player;
    [SerializeField]
    EnemyBoneCast enemy;


    public void ThrowBones(Fsm fsm)
    {
        StartCoroutine(Cast(fsm));
    }

    private IEnumerator Cast(Fsm fsm)
    {
        player.Cast();
        yield return new WaitForSeconds(5);
        enemy.Cast();
        yield return new WaitForSeconds(5);
        fsm.NextState();
    }
}
