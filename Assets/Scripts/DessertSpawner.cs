using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DessertSpawner : MonoBehaviour
{
    [SerializeField] private Image[] _dessertImages;

    private int _randomDessertIndex;
    private float _timer = 0;

    private float _secondsBetweenSpawns;
    private float _fastestSpawnRate = 0.2f;
    private float _slowestSpawnRate = 0.5f;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _secondsBetweenSpawns)
        {
            SpawnNextDessert();
            _secondsBetweenSpawns = Random.Range(_fastestSpawnRate, _slowestSpawnRate);
            _timer = 0;
        }
    }

    private void SpawnNextDessert()
    {
        _randomDessertIndex = (int)Random.Range(0f, _dessertImages.Length - 1);
        Vector2 randomVector = MyToolBox.GetRandomVector2(-transform.position.x + 10,
            transform.position.x - 10, transform.position.y + 60, transform.position.y + 60);

        Image spawnedDessert = Instantiate(_dessertImages[_randomDessertIndex], transform);
        spawnedDessert.transform.localPosition = randomVector;
    }
}
