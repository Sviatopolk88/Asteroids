using UnityEngine;

public class SmallAsteroidMove : BaseMovement
{
    private void Start()
    {
        transform.Rotate(0, 0, Random.Range(0, 360));
        _speed = Random.Range(2.5f, 4.0f);
    }
}
