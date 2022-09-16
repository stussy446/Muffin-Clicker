using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    private int _counter = 0;

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
        _counter++;
        Debug.Log(_counter);
    }
}

