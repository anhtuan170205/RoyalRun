using UnityEngine;

public class Apple : Pickup
{
    protected override void OnPickup()
    {
        LevelGenerator.Instance.ChangeLevelSpeed(2f);
        Destroy(gameObject);
    }
}
