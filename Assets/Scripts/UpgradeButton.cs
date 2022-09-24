using UnityEngine;
using TMPro;

/// <summary>
/// Handles on click events for the Upgrade Button
/// </summary>
public class UpgradeButton : MonoBehaviour
{
    private int _currentUpgradeCost = 10;
    private int _currentLevel = 1;

    [SerializeField]private int _upgradeCostIncrease;
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
            _currentUpgradeCost += _upgradeCostIncrease;
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
}
