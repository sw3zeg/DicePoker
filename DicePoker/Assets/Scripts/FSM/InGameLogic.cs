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
        player.ThrowBones();
        yield return new WaitForSeconds(5);
        enemy.ThrowBones();
        yield return new WaitForSeconds(5);
        fsm.NextState();
    }
}
