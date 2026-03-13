using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : SingletonMonoBehaviour<LevelGenerator>
{
    [SerializeField] private ChunkPool _chunkPool;
    [SerializeField] private int _initialChunksCount = 5;
    [SerializeField] private float _chunkLength = 10f;
    [SerializeField] private float _moveSpeed = 5f;

    private readonly List<Chunk> _activeChunks = new List<Chunk>();
    private Camera _mainCamera;

    protected override void Awake()
    {
        base.Awake();
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        SpawnInitialChunks();
    }

    private void Update()
    {
        MoveChunks();
    }

    private void SpawnInitialChunks()
    {
        for (int i = 0; i < _initialChunksCount; i++)
        {
            SpawnChunk();
        }
    }

    private float CalculateSpawnPositionZ()
    {
        if (_activeChunks.Count == 0)
        {
            return transform.position.z;
        }

        Chunk lastChunk = _activeChunks[_activeChunks.Count - 1];
        return lastChunk.transform.position.z + _chunkLength;
    }

    private void SpawnChunk()
    {
        Chunk newChunk = _chunkPool.GetObjectFromPool();
        if (newChunk == null) { return; }

        float spawnPositionZ = CalculateSpawnPositionZ();
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);

        newChunk.transform.position = spawnPosition;
        newChunk.transform.rotation = Quaternion.identity;

        _activeChunks.Add(newChunk);
    }

    private void MoveChunks()
    {
        for (int i = 0; i < _activeChunks.Count; i++)
        {
            Chunk chunk = _activeChunks[i];
            chunk.transform.Translate(-transform.forward * _moveSpeed * Time.deltaTime);

            if (IsChunkBehindCamera(chunk))
            {
                _activeChunks.Remove(chunk);
                _chunkPool.ReturnObjectToPool(chunk);
                SpawnChunk();
            }
        }
    }

    private bool IsChunkBehindCamera(Chunk chunk)
    {
        return chunk.transform.position.z < _mainCamera.transform.position.z - _chunkLength;
    }

}
