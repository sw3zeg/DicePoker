using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class RerolChoseLogic : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private List<Selection> selections = new List<Selection>();
        
        public void EnableMenu()
        {
            menu.gameObject.SetActive(true);
            foreach (Selection selection in selections)
                selection.EnableChoceMode();
        }

        public void DesableMenu()
        {
            menu.gameObject.SetActive(false);
            foreach (Selection selection in selections)
                selection.DesableChoceMode();
        }
    }
}