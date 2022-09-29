using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Muffins Per Click Upgrades
/// </summary>
public class MPCUpgradeButton : UpgradeButton
{
    private int _mpcUpgradeCost = 5;
    private int _mpcLevel = 1;

    public override int CurrentUpgradeCost { get => _mpcUpgradeCost; set => _mpcUpgradeCost = value; }
    public override int CurrentLevel { get => _mpcLevel; set => _mpcLevel = value; }

    public override void PurchaseUpgrade()
    {
        if (GameManager.TotalMuffins >= CurrentUpgradeCost)
        {
            CurrentLevel++;
            GameManager.ApplyMuffinsPerClickUpgrade(CurrentUpgradeCost, CurrentLevel);
            CurrentUpgradeCost += Mathf.RoundToInt(Mathf.Pow(CurrentLevel - 1, PowerIncrease));
            SetUpgradeText();
        }
    }
}
