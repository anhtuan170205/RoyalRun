using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstaclePrefabs;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private Transform _obstacleParent;

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
        int randomIndex = Random.Range(0, _obstaclePrefabs.Count);
        Instantiate(_obstaclePrefabs[randomIndex], spawnPosition, Quaternion.identity, _obstacleParent);
        _spawnedObstaclesCount++;
    }
}
