using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    private int _currentUpgradeCost = 10;
    private int _currentLevel = 1;

    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    public void PurchaseUpgrade()
    {
        //if (GameManager.g)
        //{

        //}
    }

    private void SetText()
    {
        Debug.Log("hello");
        _levelText.text = $"{_currentLevel}";
        _priceText.text = $"{_currentUpgradeCost}";
    }
}
