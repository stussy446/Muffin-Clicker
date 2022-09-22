using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _counter = 0;

    [SerializeField] private int _muffinsPerClick = 1;
    [SerializeField] Header _header;

    [Range(0, 100)]
    [SerializeField] private int _criticalPercentChance = 1;

    void Start()
    {
        _header.UpdateTotalMuffins(_counter);
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
        _header.UpdateTotalMuffins(_counter);

        return addedMuffins;

    }

  
}
