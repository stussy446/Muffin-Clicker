using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 1. Floats the text upwards
/// 2. Fades the text
/// 3. Destroys the text
/// </summary>

public class FloatingText : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;

    private TextMeshProUGUI _rewardText;
    private float _timer;
    private Color _startColor;

    // Start is called before the first frame update
    void Start()
    {
        _rewardText = GetComponent<TextMeshProUGUI>();
        _startColor = _rewardText.color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
        _timer += Time.deltaTime;
        _rewardText.color = Color.Lerp(_startColor, Color.clear, _timer);

        if (_timer >= 1)
        {
            Destroy(gameObject);
        }

    }
}
