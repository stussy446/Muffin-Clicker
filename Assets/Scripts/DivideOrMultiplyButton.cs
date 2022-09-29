using UnityEngine;

public class DivideOrMultiplyButton : UpgradeButton
{
    public bool DoubleClicks
    {
        get
        {
            return Random.Range(0, 2) == 0;
        }
    }
}
