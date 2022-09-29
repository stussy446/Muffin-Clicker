using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles Muffin Clicker Game State
/// </summary>
public class GameManager : MonoBehaviour
{
    public UnityEvent<int> OnTotalMuffinsChanged;
    public UnityEvent<int> OnMuffinsPerSecondChanged;

    private int _muffinsPerClick = 1;
    private int _totalMuffins;
    private int _muffinsPerSecond;

    [Range(0, 100)]
    [SerializeField] private int _criticalPercentChance = 1;
    [SerializeField] private UpgradeType _upgradeType;

    public int TotalMuffins
    {
        get
        {
            return _totalMuffins;
        }
        private set
        {
            _totalMuffins = value;
            OnTotalMuffinsChanged?.Invoke(_totalMuffins);
        }
    }

    public int MuffinsPerSecond { get => _muffinsPerSecond; set => _muffinsPerSecond = value; }
    public int MuffinsPerClick { get => _muffinsPerClick; set => _muffinsPerClick= value; }


    void Start()
    {
        TotalMuffins = 0;
        InvokeRepeating("AddMuffinsPerSecond", 0.1f, 1f);
    }

    /// <summary>
    /// Adds muffins to the current total muffins
    /// </summary>
    /// <returns>Returns the added muffins</returns>
    public int AddMuffins()
    {
        int addedMuffins = 0;
        int randomNum = Random.Range(1, 100);

        if (randomNum <= _criticalPercentChance)
        {
            addedMuffins += _muffinsPerClick * 10;
        }
        else
        {
            addedMuffins += _muffinsPerClick;
        }

        TotalMuffins += addedMuffins;

        return addedMuffins;
    }

    /// <summary>
    /// Increases upgrade to the current level of player and subtracts
    /// the cost of the upgrade from the total muffins
    /// </summary>
    /// <param name="currentUpgradeCost">cost of the upgrade</param>
    /// <param name="currentLevel">current level of the player</param>
    public void ApplyMuffinsPerClickUpgrade(int currentUpgradeCost, int currentLevel)
    {
        TotalMuffins -= currentUpgradeCost;
        MuffinsPerClick = currentLevel;
    }

    public void ApplyMuffinsPerSecondUpgrade(int currentUpgradeCost, int currentLevel)
    {
        TotalMuffins -= currentUpgradeCost;
        MuffinsPerSecond = currentLevel;
        OnMuffinsPerSecondChanged?.Invoke(MuffinsPerSecond);
    }

    public void ApplyUpgrade(int currentUpgradeCost, int currentLevel, UpgradeType upgradeType)
    {
        TotalMuffins -= currentUpgradeCost;
        switch (upgradeType)
        {
            case UpgradeType.MuffinUpgrade:
                MuffinsPerClick = currentLevel;
                break;
            case UpgradeType.SugarRushUpgrade:
                MuffinsPerSecond = currentLevel;
                OnMuffinsPerSecondChanged?.Invoke(MuffinsPerSecond);
                break;
            default:
                break;
        }
    }

    private void AddMuffinsPerSecond()
    {
        TotalMuffins += MuffinsPerSecond;
    }


}