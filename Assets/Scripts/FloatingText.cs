using UnityEngine;
using TMPro;

/// <summary>
/// Handles text floating up and fading away
/// </summary>
public class FloatingText : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private TextMeshProUGUI _rewardText;
    private float _timer;
    private Color _startColor;

    void Start()
    {
        _rewardText = GetComponent<TextMeshProUGUI>();
        _startColor = _rewardText.color;
    }

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
