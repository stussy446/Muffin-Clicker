using UnityEngine;

/// <summary>
/// Handles Muffin Clicker Game State
/// </summary>
public class GameManager : MonoBehaviour
{
    private int _muffinsPerClick = 1;

    [SerializeField] Header _header;
    [Range(0, 100)]
    [SerializeField] private int _criticalPercentChance = 1;

    public int TotalMuffins { get; private set; }

    void Start()
    {
        _header.UpdateTotalMuffins(TotalMuffins);
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
        _header.UpdateTotalMuffins(TotalMuffins);

        return addedMuffins;
    }

    /// <summary>
    /// Increases muffins per click to the current level of player and subtracts
    /// the cost of the upgrade from the total muffins
    /// </summary>
    /// <param name="currentUpgradeCost">cost of the upgrade</param>
    /// <param name="currentLevel">current level of the player</param>
    internal void ApplyMuffinsPerClickUpgrade(int currentUpgradeCost, int currentLevel)
    {
        TotalMuffins -= currentUpgradeCost;
        _muffinsPerClick = currentLevel;
        _header.UpdateTotalMuffins(TotalMuffins);
    }
}
