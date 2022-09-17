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
    [SerializeField] private Transform _spinLight1, _spinLight2;
    [SerializeField] private float _spinSpeed = 360f;
    [SerializeField] private float _sinDistance = 1f;
    [SerializeField] private float _sinSpeed = 1f;
    [SerializeField] private float _waveOffset = 0f;

    void Start()
    {
        UpdateTotalMuffins();
    }

    private void Update()
    {
        Vector3 rotation = new Vector3();
        rotation.z = _spinSpeed * Time.deltaTime;
        _spinLight1.Rotate(rotation);
        _spinLight2.Rotate(rotation);
        PulseSpinLight(_spinLight1);
        PulseSpinLight(_spinLight2);


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

    void PulseSpinLight(Transform spinLight)
    {
        float sin = (Mathf.Sin(Time.time * _sinSpeed) * _sinDistance) + _waveOffset;
        spinLight.transform.localScale = new Vector3(sin, sin, 0f);
    }
}

