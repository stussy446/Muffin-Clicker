using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyFirstScript : MonoBehaviour
{
    private float[] _spinSpeeds;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private Transform[] _spinLights;
    [SerializeField] private float _sinDistance = 1f;
    [SerializeField] private float _sinSpeed = 1f;
    [SerializeField] private float _waveOffset = 0f;

    [SerializeField] private TextMeshProUGUI _textRewardPrefab;
    [SerializeField] private float _textMinSpawnX = -150f;
    [SerializeField] private float _textMaxSpawnX = 180f;
    [SerializeField] private float _textMinSpawnY = -150f;
    [SerializeField] private float _textMaxSpawnY = 150f;

    private void Awake()
    {
        SetLightSpinSpeeds();
    }

    private void Update()
    {
        for (int i = 0; i < _spinLights.Length; i++)
        {
            RotateLight(_spinLights[i], _spinSpeeds[i]);
            PulseSpinLight(_spinLights[i]);
        }
    }

    private void SetLightSpinSpeeds()
    {
        _spinSpeeds = new float[_spinLights.Length];

        for (int i = 0; i < _spinSpeeds.Length; i++)
        {
            _spinSpeeds[i] = Random.Range(1, 360);
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

    public void OnMuffinClicked()
    {
        int addedMuffins = gameManager.AddMuffins();
        GenerateRewardText(addedMuffins);
    }

    private void GenerateRewardText(int addedMuffins)
    {
        TextMeshProUGUI textRewardClone = Instantiate(_textRewardPrefab, transform);
        Vector2 randomSpawnPoint = MyToolBox.GetRandomVector2
            (_textMinSpawnX, _textMaxSpawnX,
             _textMinSpawnY, _textMaxSpawnY);

        textRewardClone.transform.localPosition = randomSpawnPoint;
        textRewardClone.text = "+" + addedMuffins;
    }
}
