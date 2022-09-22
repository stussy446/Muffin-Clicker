using UnityEngine;

/// <summary>
/// Controls the spinlight's spin speed based on a randomly generated number
/// between 1 and 360 inclusive
/// </summary>
public class LightSpinHandler : MonoBehaviour
{
    private float _spinSpeed;

    private void Start()
    {
        SetLightSpinSpeed();    
    }

    private void Update()
    {
        RotateLight();
    }

    private void SetLightSpinSpeed()
    {
        _spinSpeed = Random.Range(1, 360);
    }

    private void RotateLight()
    {
        Vector3 rotation = new Vector3(0, 0, _spinSpeed * Time.deltaTime);
        transform.Rotate(rotation);
    }
}
