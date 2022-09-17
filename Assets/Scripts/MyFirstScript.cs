using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyFirstScript : MonoBehaviour
{
    private int _counter = 0;

    [SerializeField] private int _muffinsPerClick = 1;
    [Range(0, 100)][SerializeField] private int _criticalPercentChance = 1;
    [SerializeField] private TextMeshProUGUI _totalMuffinsText;

    void Start()
    {
        UpdateTotalMuffins();
    }

    public void OnMuffinClicked()
    {
        if (IsCriticalClick()) 
        {
            _counter += _muffinsPerClick * 10;
        }
        else
        {
            _counter += _muffinsPerClick;
        }

        UpdateTotalMuffins();
    }

    private void UpdateTotalMuffins()
    {
        if (_counter == 1)
        {
            _totalMuffinsText.text = _counter.ToString() + " Muffin";
        }
        else
        {
            _totalMuffinsText.text = _counter.ToString() + " Muffins";
        }
    }

    private bool IsCriticalClick()
    {
        int randomNum = Random.Range(1, 100);

        if (randomNum <= _criticalPercentChance)
        {
            Debug.Log("critical click!");
            return true;
        }
        else
        {
            return false;
        }
    }
}

