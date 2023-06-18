using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
        public static List<int> selectedDices  = new List<int>();

        public static void AddDice(int num)
        {
                selectedDices.Add(num);
        }
        
        public static void RemoveDice(int num)
        {
                selectedDices.Remove(num);
        }
}