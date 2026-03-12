using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private float _moveSpeed = 5f;
    public float MoveSpeed => _moveSpeed;

}
