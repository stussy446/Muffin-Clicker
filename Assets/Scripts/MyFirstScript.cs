using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyFirstScript : MonoBehaviour
{
    private int _counter = 0;
    private float[] _spinSpeeds;

    [SerializeField] private int _muffinsPerClick = 1;
    [Range(0, 100)][SerializeField] private int _criticalPercentChance = 1;
    [SerializeField] private TextMeshProUGUI _totalMuffinsText;
    [SerializeField] private Transform[] _spinLights;
    [SerializeField] private float _sinDistance = 1f;
    [SerializeField] private float _sinSpeed = 1f;
    [SerializeField] private float _waveOffset = 0f;

    void Start()
    {
        UpdateTotalMuffins();
        SetSpinSpeeds();
    }

    private void Update()
    {
        for (int i = 0; i < _spinLights.Length; i++)
        {
            RotateLight(_spinLights[i], _spinSpeeds[i]);
            PulseSpinLight(_spinLights[i]);
        }
    }

    private void SetSpinSpeeds()
    {
        _spinSpeeds = new float[_spinLights.Length];

        for (int i = 0; i < _spinSpeeds.Length; i++)
        {
            _spinSpeeds[i] = Random.Range(1, 360);
        }
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

    private void RotateLight(Transform _spinLight, float _spinSpeed)
    {
        Vector3 rotation = new Vector3(0, 0, _spinSpeed * Time.deltaTime);
        _spinLight.Rotate(rotation);
    }

    private void PulseSpinLight(Transform _spinLight)
    {
        float sin = (Mathf.Sin(Time.time * _sinSpeed) * _sinDistance) + _waveOffset;
        _spinLight.transform.localScale = new Vector3(sin, sin, 0f);
    }
}

