using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const float MAX_SPEED = 6f;
    public float Direction => transform.eulerAngles.z;
    public float Speed => (Mathf.Abs(_speed.x) + Mathf.Abs(_speed.y)) / 2;

    private PlayerInput _input;
    private ScreenTeleport _teleport;

    private Vector2 _speed;

    private int _rotationCoefficient = -300;

    private bool _flagAcceleration = false;

    private void Awake()
    {
        _input = new PlayerInput();
        _teleport = new ScreenTeleport();
        transform.position = new Vector3(0 - _teleport.RightPanelSize / 2, 0, 0);
    }

    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        Vector2 direction = _input.Player.Rotation.ReadValue<Vector2>();
        transform.Rotate(0, 0, _rotationCoefficient * direction.x * Time.deltaTime);

        var acceleration = _input.Player.Acceleration.ReadValue<float>();
        Move(acceleration);
    }

    private void Move(float acceleration)
    {
        _teleport.BorderCrossing(this.transform);

        if (acceleration == 1)
        {
            var moveX = -Mathf.Sin(Mathf.Deg2Rad * Direction);
            var moveY = Mathf.Cos(Mathf.Deg2Rad * Direction);

            _speed += new Vector2(moveX, moveY) / 10;
            MaxSpeed();
            if (_flagAcceleration == false)
            {
                _flagAcceleration = true;
                SoundManager.Instance.RocketMove();
            }
        }
        else
        {
            SoundManager.Instance.RocketStop();
            _flagAcceleration = false;
        }

        _speed -= _speed / 100;
        transform.Translate(_speed * Time.deltaTime, Space.World);
        
    }

    private void MaxSpeed()
    {
        if (_speed.x > MAX_SPEED) _speed.x = MAX_SPEED;
        else if (_speed.x < -MAX_SPEED) _speed.x = -MAX_SPEED;

        if (_speed.y > MAX_SPEED) _speed.y = MAX_SPEED;
        else if (_speed.y < -MAX_SPEED) _speed.y = -MAX_SPEED;
    }
}
