using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyFirstScript : MonoBehaviour
{
    private int _counter = 0;

    [SerializeField] private int _muffinsPerClick = 1;
    [SerializeField] private TextMeshProUGUI _totalMuffinsText;

    void Start()
    {
        Debug.Log("hello world");
        UpdateTotalMuffins();
    }

    public void OnMuffinClicked()
    {
        _counter += _muffinsPerClick;
        UpdateTotalMuffins();
        Debug.Log(_counter);
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

