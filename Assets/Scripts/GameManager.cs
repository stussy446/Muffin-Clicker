using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles Muffin Clicker Game State
/// </summary>
public class GameManager : MonoBehaviour
{
    public UnityEvent<int> OnTotalMuffinsChanged;

    private int _muffinsPerClick = 1;
    private int _totalMuffins;
    private int _muffinsPerSecond;

    [Range(0, 100)]
    [SerializeField] private int _criticalPercentChance = 1;

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

    public int MuffinsPerSecond { get; private set; }
    public int MuffinsPerClick { get; private set; }


    void Start()
    {
        TotalMuffins = 0;
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
    internal void ApplyUpgrade(int currentUpgradeCost, int upgradeValue, int currentLevel)
    {
        TotalMuffins -= currentUpgradeCost;
        upgradeValue = currentLevel;
    }


}