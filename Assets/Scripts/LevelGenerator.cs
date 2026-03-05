using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _chunkPrefab;
    [SerializeField] private int _initialChunks = 5;
    [SerializeField] private Transform _chunkParent;
    [SerializeField] private float _chunkLength = 10f;

    private void Start()
    {
        for (int i = 0; i < _initialChunks; i++)
        {
            Instantiate(_chunkPrefab, new Vector3(0, 0, i * _chunkLength), Quaternion.identity, _chunkParent);
        }

    }
}
