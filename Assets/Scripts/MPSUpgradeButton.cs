using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MPSUpgradeButton : UpgradeButton
{
    private int _mpsUpgradeCost = 5;
    private int _mpsLevel = 0;

    public override int CurrentUpgradeCost { get => _mpsUpgradeCost; set => _mpsUpgradeCost = value; }
    public override int CurrentLevel { get => _mpsLevel; set => _mpsLevel = value; }

    public override void PurchaseUpgrade()
    {
        if (GameManager.TotalMuffins >= CurrentUpgradeCost)
        {
            CurrentLevel++;
            GameManager.ApplyMuffinsPerSecondUpgrade(CurrentUpgradeCost, CurrentLevel);
            CurrentUpgradeCost += Mathf.RoundToInt(Mathf.Pow(CurrentLevel - 1, PowerIncrease));
            SetUpgradeText();
        }
    }

}
