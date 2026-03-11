using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _chunkPrefab;
    [SerializeField] private int _initialChunksCount = 10;
    [SerializeField] private Transform _chunkParent;
    [SerializeField] private float _chunkLength = 10f;
    [SerializeField] private float _moveSpeed = 5f;

    private List<GameObject> _activeChunks = new List<GameObject>();

    private void Start()
    {
        SpawnInitialChunks();
    }

    private void SpawnInitialChunks()
    {
        for (int i = 0; i < _initialChunksCount; i++)
        {
            SpawnChunk();
        }
    }

    private void Update()
    {
        MoveChunks();
    }

    private float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;

        if (_activeChunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            GameObject lastChunk = _activeChunks[_activeChunks.Count - 1];
            spawnPositionZ = lastChunk.transform.position.z + _chunkLength;
        }

        return spawnPositionZ;
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newChunk = Instantiate(_chunkPrefab, spawnPosition, Quaternion.identity, _chunkParent);
        _activeChunks.Add(newChunk);
    }

    private void MoveChunks()
    {
        for (int i = 0; i < _activeChunks.Count; i++)
        {
            GameObject chunk = _activeChunks[i];
            chunk.transform.Translate(-transform.forward * _moveSpeed * Time.deltaTime);

            if (chunk.transform.position.z <= Camera.main.transform.position.z - _chunkLength)
            {
                _activeChunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }

}
