using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private float _spawnInterval = 2f;

    private int _spawnedObstaclesCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (_spawnedObstaclesCount < 10)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-3f, 3f), 5, transform.position.z);
        Instantiate(_obstaclePrefab, spawnPosition, Random.rotation);
        _spawnedObstaclesCount++;
    }
}
