using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _counter = 0;

    [SerializeField] private TextMeshProUGUI _totalMuffinsText;
    [SerializeField] private int _muffinsPerClick = 1;

    [Range(0, 100)]
    [SerializeField] private int _criticalPercentChance = 1;

    void Start()
    {
        UpdateTotalMuffins();
    }

    public int AddMuffins()
    {
        int addedMuffins = 0;
        int randomNum = Random.Range(1, 100);

        if (randomNum <= _criticalPercentChance)
        {
            addedMuffins += _muffinsPerClick * 10;
        }
        else
        {
            addedMuffins += _muffinsPerClick;
        }

        _counter += addedMuffins;
        UpdateTotalMuffins();

        return addedMuffins;

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
}
