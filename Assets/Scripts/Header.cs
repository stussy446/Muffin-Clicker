using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class Header : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalMuffinsText;

    public void UpdateTotalMuffins(int counter)
    {
        if (counter == 1)
        {
            _totalMuffinsText.text = counter.ToString() + " Muffin";
        }
        else
        {
            _totalMuffinsText.text = counter.ToString() + " Muffins";
        }
    }

}
