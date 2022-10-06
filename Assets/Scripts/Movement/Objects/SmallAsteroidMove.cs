using UnityEngine;

public class SmallAsteroidMove : BaseMovement
{
    private void Start()
    {
        _speed = Random.Range(2.5f, 4.0f);
    }
}
