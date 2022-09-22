using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyFirstScript : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private TextMeshProUGUI _textRewardPrefab;
    [SerializeField] private float _textMinSpawnX = -150f;
    [SerializeField] private float _textMaxSpawnX = 180f;
    [SerializeField] private float _textMinSpawnY = -150f;
    [SerializeField] private float _textMaxSpawnY = 150f;

    public void OnMuffinClicked()
    {
        int addedMuffins = gameManager.AddMuffins();
        GenerateRewardText(addedMuffins);
    }

    private void GenerateRewardText(int addedMuffins)
    {
        TextMeshProUGUI textRewardClone = Instantiate(_textRewardPrefab, transform);

        Vector2 randomSpawnPoint = MyToolBox.GetRandomVector2
            (_textMinSpawnX, _textMaxSpawnX,
             _textMinSpawnY, _textMaxSpawnY);

        textRewardClone.transform.localPosition = randomSpawnPoint;
        textRewardClone.text = "+" + addedMuffins;
    }
}
