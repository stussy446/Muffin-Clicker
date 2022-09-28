using UnityEngine;
using TMPro;    

/// <summary>
/// Updates the Header children UI elements.
/// </summary>
public class Header : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalMuffinsText;
    [SerializeField] private TextMeshProUGUI _muffinPerSecondText;


    /// <summary>       
    /// Updates the total muffins text
    /// </summary>
    /// <param name="counter">The total muffins</param>
    public void UpdateTotalMuffins(int counter)
    {
        _totalMuffinsText.text = counter == 1 ?
            $"{counter} muffin" :
            $"{counter} muffins";
    }

    public void UpdateMuffinsPerSecond(int muffinsPerSecond)
    {
        _muffinPerSecondText.text = $"{muffinsPerSecond} Muffins/Second";
    }

}
