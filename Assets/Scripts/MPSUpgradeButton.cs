using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MPSUpgradeButton : UpgradeButton
{
    private int _mpsUpgradeCost = 5;

    public override int CurrentUpgradeCost { get => _mpsUpgradeCost; set => _mpsUpgradeCost = value; }
    // Start is called before the first frame update
    void Start()
    {
        SetUpgradeText();
    }

    public override void PurchaseUpgrade()
    {
        if (GameManager.TotalMuffins >= CurrentUpgradeCost)
        {
            CurrentLevel++;
            GameManager.ApplyUpgrade(CurrentUpgradeCost, GameManager.MuffinsPerClick, CurrentLevel);
            CurrentUpgradeCost += Mathf.RoundToInt(Mathf.Pow(CurrentLevel - 1, PowerIncrease));
            SetUpgradeText();
        }
        else
        {
            Debug.Log("not enough points");
        }
    }

}
