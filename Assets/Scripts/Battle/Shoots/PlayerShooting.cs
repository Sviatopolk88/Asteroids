using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _bulletPrefab;
    [SerializeField] private Transform _laserPrefab;
    [SerializeField] private Transform _shells; // Объект для хранения снарядов

    [SerializeField] private int _maxBullets = 20;
    [SerializeField] private int _maxLasers = 3;

    public float Timer => _timer;

    private List<Transform> _bullets = new List<Transform>();
    private List<Transform> _lasers = new List<Transform>();

    private PlayerInput _input;
    private ShootingLogic _shoot;

    private float _timer;
    private float _rechargeTime = 15f;

    private void Awake()
    {
        _input = new PlayerInput();
        
        _input.Player.ShootBullet.performed += context => _shoot.ShootBullet(this.transform);
        _input.Player.ShootLaser.performed += context => _shoot.ShootLaser(this.transform);
    }

    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }

    private void Start()
    {
        ShellsInstantiate();
        _shoot = new ShootingLogic(_bullets, _lasers);
    }

    private void Update()
    {
        if (_shoot.AvailableLaserCharges != _shoot.MaxLasers)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _shoot.RechargeLaser();
                _timer = _rechargeTime;
            }
        }
    }

    private void ShellsInstantiate()
    {
        for (int i = 0; i < _maxBullets; i++)
        {
            var bullet = Instantiate(_bulletPrefab, _shells);
            _bullets.Add(bullet);
            bullet.gameObject.SetActive(false);
        }

        for (int i = 0; i < _maxLasers; i++)
        {
            var laser = Instantiate(_laserPrefab, _shells);
            _lasers.Add(laser);
            laser.gameObject.SetActive(false);
        }
    }
}
