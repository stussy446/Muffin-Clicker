using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DessertSpawner : MonoBehaviour
{
    [SerializeField] private Image[] _dessertImages;
    [SerializeField] private float _secondsBetweenSpawns = 1f;

    const float ParentY = 608f;
    const float ParentX = 960f;

    private int _randomDessertIndex;
    private float _timer = 0;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _secondsBetweenSpawns)
        {
            SpawnNextDessert();
            _timer = 0;
        }
    }

    private void SpawnNextDessert()
    {
        _randomDessertIndex = (int)Random.Range(0f, _dessertImages.Length - 1);
        Vector2 randomVector = MyToolBox.GetRandomVector2(-ParentX, ParentX, ParentY, ParentY);
        Image spawnedDessert = Instantiate(_dessertImages[_randomDessertIndex], transform);

        spawnedDessert.transform.localPosition = randomVector;
    }
}
