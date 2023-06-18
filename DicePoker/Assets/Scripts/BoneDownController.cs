using System;
using UnityEngine;

public class BoneDownController : MonoBehaviour
{
    public static int dicesDownCount = 0;
    
    private void OnTriggerStay(Collider dice)
    {
        switch (dice.name)
        {
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
                GameObject thisDice = dice.gameObject.transform.parent.gameObject;
                Vector3 diceVelocity = thisDice.GetComponent<Rigidbody>().velocity;
                
                if (diceVelocity is { x: 0f, y: 0f, z: 0f })
                {
                    thisDice.GetComponent<Bone>().boneNum = Convert.ToInt32(dice.gameObject.name);
                    dicesDownCount++;
                    thisDice.GetComponent<Bone>().DesableColliders();
                }
                break;
        }
    }
}
