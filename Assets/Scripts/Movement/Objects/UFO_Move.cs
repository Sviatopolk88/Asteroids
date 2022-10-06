using UnityEngine;

public class UFO_Move : BaseMovement
{
    [SerializeField] private Transform _target;

    private void Start()
    {
        _speed = 2.5f;
    }
    public override void Move()
    {
        var step = Speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _target.position, step);
    }
}
