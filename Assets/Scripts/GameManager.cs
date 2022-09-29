using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles Muffin Clicker Game State
/// </summary>
public class GameManager : MonoBehaviour
{
    public UnityEvent<int> OnTotalMuffinsChanged;
    public UnityEvent<int> OnMuffinsPerSecondChanged;

    private int _muffinsPerClick = 1;
    private int _totalMuffins;
    private int _muffinsPerSecond;
    private int _fancyMuffin;

    [Range(0, 100)]
    [SerializeField] private int _criticalPercentChance = 1;
    [SerializeField] private UpgradeType _upgradeType;
    [SerializeField] DivideOrMultiplyButton _fancyMuffinButton;

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

    public int MuffinsPerSecond { get => _muffinsPerSecond; set => _muffinsPerSecond = value; }
    public int MuffinsPerClick { get => _muffinsPerClick; set => _muffinsPerClick= value; }

    void Start()
    {
        TotalMuffins = 0;
        InvokeRepeating("AddMuffinsPerSecond", 0.1f, 1f);
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

    public void ApplyUpgrade(int currentUpgradeCost, int currentLevel, UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.MuffinUpgrade:
                TotalMuffins -= currentUpgradeCost;
                MuffinsPerClick = currentLevel;
                break;
            case UpgradeType.SugarRushUpgrade:
                TotalMuffins -= currentUpgradeCost;
                MuffinsPerSecond = currentLevel;
                OnMuffinsPerSecondChanged?.Invoke(MuffinsPerSecond);
                break;
            case UpgradeType.FancyMuffinUpgrade:
                CheckForDoubleOrDivide();
                StartCoroutine(ShowResult(currentUpgradeCost));
                break;
            default:
                break;
        }
    }

    IEnumerator ShowResult(int upgradeCost)
    {
        yield return new WaitForSeconds(1f);
        TotalMuffins -= upgradeCost;
        if (TotalMuffins < 0) { TotalMuffins = 0; }
        OnTotalMuffinsChanged?.Invoke(TotalMuffins);

    }

    private void CheckForDoubleOrDivide()
    {
        if (_fancyMuffinButton.DoubleClicks)
        {
            TotalMuffins *= 2;
            Debug.Log($"DoubleClicks is true so TotalMuffins is multiplied and is {TotalMuffins}");

        }
        else
        {
            TotalMuffins = Mathf.RoundToInt(TotalMuffins / 2);
            Debug.Log($"DoubleClicks is false so TotalMuffins is divided and is {TotalMuffins}");
        }
        OnTotalMuffinsChanged?.Invoke(TotalMuffins);

    }

    private void AddMuffinsPerSecond()
    {
        TotalMuffins += MuffinsPerSecond;
    }

}