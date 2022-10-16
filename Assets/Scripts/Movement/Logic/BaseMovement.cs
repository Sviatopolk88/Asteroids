using UnityEngine;

public class BaseMovement : MonoBehaviour, IMove
{
    private ScreenTeleport _teleport;
    protected float _speed;

    public float Speed { get { return _speed; } }

    private void Awake()
    {
        
        _teleport = new ScreenTeleport();
    }

    private void Update()
    {
        Move();
        Teleport();
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }

    private void Teleport()
    {
        _teleport.BorderCrossing(this.transform);
    }
}
