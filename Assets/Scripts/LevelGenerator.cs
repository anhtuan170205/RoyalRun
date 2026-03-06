using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _chunkPrefab;
    [SerializeField] private int _initialChunks = 5;
    [SerializeField] private Transform _chunkParent;
    [SerializeField] private float _chunkLength = 10f;
    [SerializeField] private float _moveSpeed = 5f;

    private GameObject[] _activeChunks = new GameObject[5];

    private void Start()
    {
        SpawnChunks();
    }

    private void SpawnChunks()
    {
        for (int i = 0; i < _initialChunks; i++)
        {
            Vector3 spawnPosition = new Vector3(0, 0, i * _chunkLength);
            GameObject newChunk =Instantiate(_chunkPrefab, spawnPosition, Quaternion.identity, _chunkParent);
            _activeChunks[i] = newChunk;
        }
    }

    private void Update()
    {
        MoveChunks();
    }

    private void MoveChunks()
    {
        if (_activeChunks == null) return;
        for (int i = 0; i < _activeChunks.Length; i++)
        {
            _activeChunks[i].transform.Translate(-transform.forward * _moveSpeed * Time.deltaTime);
        }
    }

}
