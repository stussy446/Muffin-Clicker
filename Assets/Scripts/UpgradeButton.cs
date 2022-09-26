using UnityEngine;
using TMPro;

/// <summary>
/// Handles on click events for the Upgrade Button
/// </summary>
public class UpgradeButton : MonoBehaviour
{
    private int _currentUpgradeCost = 5;
    private int _currentLevel = 1;
    private int _upgradeCostIncrease;

    [SerializeField] private float _powerIncrease;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private GameManager _gameManager;

    void Start()
    {
        SetUpgradeText();
    }

    /// <summary>
    /// called when the upgrade button is clicked, checks if player has enough
    /// points for an upgrade and has the gameManager apply the upgrade if it does
    /// </summary>
    public void PurchaseUpgrade()
    {
        if (_gameManager.TotalMuffins >= _currentUpgradeCost)
        {
            _currentLevel++;
            _gameManager.ApplyMuffinsPerClickUpgrade(_currentUpgradeCost, _currentLevel);
            _currentUpgradeCost += Mathf.RoundToInt(Mathf.Pow(_currentLevel - 1, _powerIncrease));
            SetUpgradeText();
        }
        else
        {
            Debug.Log("not enough points");
        }
    }

    private void SetUpgradeText()
    {
        _levelText.text = $"{_currentLevel}";
        _priceText.text = $"{_currentUpgradeCost}";
    }

    public void TotalMuffinsChanged(int totalMuffins)
    {
        bool canAfford = totalMuffins >= _currentUpgradeCost;
        if (canAfford)
        {
            _priceText.color = Color.green;
        }
        else
        {
            _priceText.color = Color.red;

        }
    }
}
