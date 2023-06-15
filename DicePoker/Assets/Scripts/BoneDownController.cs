using System;
using UnityEngine;

public class BoneDownController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent.gameObject.GetComponent<Bone>().boneNum =
            Convert.ToInt32(other.gameObject.name);
    }
}
