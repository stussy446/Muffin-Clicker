using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
