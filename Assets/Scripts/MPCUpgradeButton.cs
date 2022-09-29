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
}
