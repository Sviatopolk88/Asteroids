using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Objects")]
    [Space]
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _ufo;
    [SerializeField] private UI_Manager _ui;

    [Header("Respawn asteroids")]
    [Space]
    [SerializeField] private Transform _bigAsteroidPrefab;
    [SerializeField] private Transform _smallAsteroidPrefab;
    [SerializeField] private Transform _cask;
    [SerializeField] private int _amountAsteroids;
    [SerializeField] private int _amountSpawnStartingAsteroids = 7;
    [SerializeField] private int _amountChipsAsteroid = 3;

    [Header("Time respawn")]
    [Space]
    [SerializeField] private float _timeRespawnAsteroids = 9f;
    [SerializeField] private float _timeRespawnUFO = 15f;

    [Space]
    [SerializeField] private PlayerShooting _shoot;

    private RespawnLogic _respawn;

    private PlayerData _playerData;

    private void Start()
    {
        _respawn = new RespawnLogic();
        _playerData = new PlayerData();
        AsteroidsInstantiate();
        _respawn.RespawnAsteroid(_player, _amountSpawnStartingAsteroids);
        StartCoroutine(_respawn.SpawnAsteroids(_player, _timeRespawnAsteroids));
        StartCoroutine(_respawn.SpawnUFO(_ufo, _player, _timeRespawnUFO));
        BigAsteroidDestruction.OnAsteroidDestruction.AddListener(LaunchChips);
        EventManager.OnAddPoints.AddListener(AddPoints);
        EventManager.OnChangeAmountLaserCharges.AddListener(AvailableLaserCharges);
        EventManager.OnGameOver.AddListener(GameOver);
    }

    private void Update()
    {
        if (_shoot.Recharge) RechargeTimer();
    }

    private void RechargeTimer()
    {
        _ui.RechargeTimer(_shoot.Timer);
    }

    private void AvailableLaserCharges(int charges)
    {
        _ui.AvailableCharges(charges);
    }

    private void AddPoints(int points)
    {
        _playerData.AddPoints(points);
        _ui.UpdateScore(_playerData.Score);
    }

    private void LaunchChips(Vector2 asteroidPosition)
    {
        _respawn.LaunchSmallAsteroids(asteroidPosition);
    }

    private void AsteroidsInstantiate()
    {
        for (int i = 0; i < _amountAsteroids; i++)
        {
            var asteroid = Instantiate(_bigAsteroidPrefab, _cask);
            _respawn.BigAsteroids.Add(asteroid);
            asteroid.gameObject.SetActive(false);
        }
        
        for (int i = 0; i < _amountAsteroids * _amountChipsAsteroid; i++)
        {
            var asteroid = Instantiate(_smallAsteroidPrefab, _cask);
            _respawn.SmallAsteroids.Add(asteroid);
            asteroid.gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        _ui.OpenMenu();
        _ui.Result(_playerData.Score);
        Time.timeScale = 0;
    }
}
