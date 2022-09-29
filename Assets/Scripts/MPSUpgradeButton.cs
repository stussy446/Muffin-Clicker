using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Handles Muffins Per Second Upgrades
/// </summary>
public class MPSUpgradeButton : UpgradeButton
{
    private int _mpsUpgradeCost = 5;
    private int _mpsLevel = 0;

    public override int CurrentUpgradeCost { get => _mpsUpgradeCost; set => _mpsUpgradeCost = value; }
    public override int CurrentLevel { get => _mpsLevel; set => _mpsLevel = value; }

}
