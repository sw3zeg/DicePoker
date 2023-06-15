using UnityEngine;

public class BoneSelection : MonoBehaviour
{
    public void Mark()
    {
        if (gameObject.active)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
}
