using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _bulletPrefab;
    [SerializeField] private Transform _laserPrefab;
    [SerializeField] private Transform _shells; // Объект для хранения снарядов

    [SerializeField] private int _maxBullets = 20;
    [SerializeField] private int _maxLaserCharges = 3;

    public float Timer => _timer;
    public int LaserCharges => _availableLaserCharges;
    public bool Recharge => LaserCharges < _maxLaserCharges;

    private PlayerInput _input;
    private ShootingLogic _shoot;

    private float _timer;
    private float _rechargeTime = 15f;
    private int _availableLaserCharges;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Player.ShootBullet.performed += context => _shoot.ShootBullet(this.transform);
        _input.Player.ShootLaser.performed += context => LaserShoot();
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
        _shoot = new ShootingLogic();
        ShellsInstantiate();
        _availableLaserCharges = _maxLaserCharges;
        _timer = _rechargeTime;
    }

    private void Update()
    {
        
        if (_availableLaserCharges < _maxLaserCharges)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _availableLaserCharges++;
                _timer = _rechargeTime;

                EventManager.SendChangeAmountLaserCharges(_availableLaserCharges);
            }
        }
    }

    private void LaserShoot()
    {
        if (Time.timeScale == 0) return;
        if (_availableLaserCharges == 0) return;

        _shoot.ShootLaser(this.transform);
        _availableLaserCharges--;

        EventManager.SendChangeAmountLaserCharges(_availableLaserCharges);
    }

    private void ShellsInstantiate()
    {
        for (int i = 0; i < _maxBullets; i++)
        {
            var bullet = Instantiate(_bulletPrefab, _shells);
            
            _shoot.Bullets.Add(bullet);
            bullet.gameObject.SetActive(false);
        }

        for (int i = 0; i < _maxLaserCharges; i++)
        {
            var laser = Instantiate(_laserPrefab, _shells);
            _shoot.LaserCharges.Add(laser);
            laser.gameObject.SetActive(false);
        }
    }
}
