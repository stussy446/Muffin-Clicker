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
}
