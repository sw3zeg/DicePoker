using System;
using UnityEngine;

public class Selection : MonoBehaviour
{
    [SerializeField] private GameObject selection;
    private Bone bone;
    private bool IsRerollChoce = false;

    private void Awake()
    {
        bone = gameObject.GetComponent<Bone>();
    }

    private void OnMouseDown()
    {
        if (IsRerollChoce)
            ChangeSelection();
    }

    private void ChangeSelection()
    {
        selection.SetActive(!selection.activeSelf);
        if (selection.activeSelf == true)
            SelectionController.AddDice(GetSelectionNum());
        else
            SelectionController.RemoveDice(GetSelectionNum());
    }

    private int GetSelectionNum()
    {
        switch (bone.name)
        {
            case "PokerBone1":
                return 0;
            case "PokerBone2":
                return 1;
            case "PokerBone3":
                return 2;
            case "PokerBone4":
                return 3;
            case "PokerBone5":
                return 4;
        }

        return -1;
    }
    
    public void EnableChoceMode()
    {
        IsRerollChoce = true;
    }
    public void DesableChoceMode()
    {
        IsRerollChoce = false;
        selection.SetActive(IsRerollChoce);
    }
}
