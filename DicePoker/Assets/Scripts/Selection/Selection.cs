using UnityEngine;

public class Selection : MonoBehaviour
{
    private bool CanSelected = false;

    private void OnMouseDown()
    {
        if (CanSelected == true)
            Debug.Log(true);
        else
            Debug.Log(false);
    }
}
