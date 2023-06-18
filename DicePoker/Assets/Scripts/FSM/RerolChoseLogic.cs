using UnityEngine;

namespace FSM
{
    public class RerolChoseLogic : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        
        public void EnableMenu()
        {
            menu.gameObject.SetActive(true);
        }

        public void DesableMenu()
        {
            menu.gameObject.SetActive(false);
        }

        public void _RerollChoceDices()
        {
            
        }

        public void _SkipReroll()
        {
            
        }
    }
}