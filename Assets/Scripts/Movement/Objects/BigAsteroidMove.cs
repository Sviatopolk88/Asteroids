using UnityEngine;

public class BigAsteroidMove : BaseMovement
{
    private void Start()
    {
        transform.Rotate(0, 0, Random.Range(0, 360));
        _speed = 1.5f;
    }
}
