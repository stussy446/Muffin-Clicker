using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulseHandler : MonoBehaviour
{
    [SerializeField] private float _sinDistance = 1f;
    [SerializeField] private float _sinSpeed = 1f;
    [SerializeField] private float _waveOffset = 0f;

    private void Update()
    {
        PulseSpinLight();
    }

    private void PulseSpinLight()
    {
        float sin = (Mathf.Sin(Time.time * _sinSpeed) * _sinDistance) + _waveOffset;
        transform.localScale = new Vector3(sin, sin, 0f);
    }
}
