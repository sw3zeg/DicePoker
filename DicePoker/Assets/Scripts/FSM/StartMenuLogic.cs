using UnityEngine;

public class StartMenuLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    public void EnableMenu()
    {
        menu.gameObject.SetActive(true);
    }

    public void DesableMenu()
    {
        menu.gameObject.SetActive(false);
    }
}
