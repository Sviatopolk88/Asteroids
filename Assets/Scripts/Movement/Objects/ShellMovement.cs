using UnityEngine;

public class ShellMovement : MonoBehaviour
{
    [SerializeField] private ShellInfo _shell;

    private float _timeLimit = 2f;
    private float _currentTime = 0f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var speed = _shell.Speed;
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.Self);
        _currentTime += Time.deltaTime;
        if (_currentTime > _timeLimit)
        {
            this.gameObject.SetActive(false);
            _currentTime = 0;
        }
    }
}
