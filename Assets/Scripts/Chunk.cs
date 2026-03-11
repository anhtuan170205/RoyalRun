using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject _fencePrefab;
    [SerializeField] private float[] _fencePositionsX = { -2.5f, 0f, 2.5f };

    private void Start()
    {
        SpawnFences();
    }

    private void SpawnFences()
    {
        int randomIndex = Random.Range(0, _fencePositionsX.Length);
        float fencePositionX = _fencePositionsX[randomIndex];
        Vector3 spawnPosition = new Vector3(fencePositionX, 0, transform.position.z);
        Instantiate(_fencePrefab, spawnPosition, Quaternion.identity, transform);
    }


}
