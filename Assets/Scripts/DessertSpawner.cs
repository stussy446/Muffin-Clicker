using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles where desserts spawn on the canvas and the rate of spawning
/// </summary>
public class DessertSpawner : MonoBehaviour
{
    [SerializeField] private Image[] _dessertImages;

    private float _timer = 0;

    private float _secondsBetweenSpawns;
    private float _fastestSpawnRate = 0.2f;
    private float _slowestSpawnRate = 0.5f;

    private float _xBoundaryOffsset = 10f;
    private float _yBoundaryOffsset = 60f;


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
        // Sets a random index, and vector position on the canvas, and spawns chosen
        // dessert at the chosen vector position
        int randomDessertIndex = (int)Random.Range(0f, _dessertImages.Length - 1);

        Vector2 randomVector = MyToolBox.GetRandomVector2(-transform.position.x + _xBoundaryOffsset,
            transform.position.x - _xBoundaryOffsset, transform.position.y + _yBoundaryOffsset,
            transform.position.y - _yBoundaryOffsset);

        Image spawnedDessert = Instantiate(_dessertImages[randomDessertIndex], transform);
        spawnedDessert.transform.localPosition = randomVector;
    }
}
