using UnityEngine;
using TMPro;

/// <summary>
/// Base class that handles on click events for Upgrade Buttons
/// </summary>
public abstract class UpgradeButton : MonoBehaviour
{
    private int _currentUpgradeCost = 5;
    private int _currentLevel = 1;
    private int _upgradeCostIncrease;

    [SerializeField] private float _powerIncrease;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private GameManager _gameManager;

    public virtual int CurrentUpgradeCost { get => _currentUpgradeCost; set => _currentUpgradeCost = value; }
    public virtual GameManager GameManager { get => _gameManager;}
    public virtual int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
    public virtual float PowerIncrease { get => _powerIncrease;}
    public virtual TextMeshProUGUI LevelText { get => _levelText; set => _levelText = value; }
    public virtual TextMeshProUGUI PriceText { get => _priceText; set => _priceText = value; }


    void Start()
    {
        SetUpgradeText();
    }

    /// <summary>
    /// called when the upgrade button is clicked, checks if player has enough
    /// points for an upgrade and has the gameManager apply the upgrade if it does
    /// </summary>
    public virtual void PurchaseUpgrade()
    {
        if (_gameManager.TotalMuffins >= CurrentUpgradeCost)
        {
            CurrentLevel++;
            GameManager.ApplyMuffinsPerClickUpgrade(CurrentUpgradeCost, CurrentLevel);
            CurrentUpgradeCost += Mathf.RoundToInt(Mathf.Pow(CurrentLevel - 1, PowerIncrease));
            SetUpgradeText();
        }
        else
        {
            Debug.Log("not enough points");
        }
    }

    public virtual void SetUpgradeText()
    {
        LevelText.text = $"{CurrentLevel}";
        PriceText.text = $"{CurrentUpgradeCost}";
    }

    public virtual void TotalMuffinsChanged(int totalMuffins)
    {
        bool canAfford = totalMuffins >= CurrentUpgradeCost;
        if (canAfford)
        {
            PriceText.color = Color.green;
        }
        else
        {
            PriceText.color = Color.red;

        }
    }
}
