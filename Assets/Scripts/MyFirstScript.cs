using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyFirstScript : MonoBehaviour
{
    private int _counter = 0;

    [SerializeField] private int _muffinsPerClick = 1;
    [SerializeField] private TextMeshProUGUI _totalMuffinsText;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello world");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMuffinClicked()
    {
        _counter += _muffinsPerClick;
        _totalMuffinsText.text = _counter.ToString();
        Debug.Log(_counter);
    }
}

