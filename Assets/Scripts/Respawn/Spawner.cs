using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _ufo;
    [SerializeField] private Transform _player;

    [Header("Respawn asteroids")]
    [Space]
    [SerializeField] private Transform _bigAsteroidPrefab;
    [SerializeField] private Transform _smallAsteroidPrefab;
    [SerializeField] private Transform _cask;
    [Range(3, 50)]
    [SerializeField] private int _amountAsteroids;
    [Range(1, 10)]
    [SerializeField] private int _amountSpawnStartingAsteroids;

    [Header("Time respawn")]
    [Space]
    [SerializeField] private float _timeRespawnAsteroids;
    [SerializeField] private float _timeRespawnUFO;

    private RespawnLogic _respawn;

    private Coroutine _spawnAsteroidsRoutine;
    private Coroutine _spawnUFORoutine;

    //private void Start()
    public void StartSpawnAsteroid()
    {
        _respawn = new RespawnLogic();

        AsteroidsInstantiate();
        _respawn.SpawnStartingAsteroids(_player, _amountSpawnStartingAsteroids);
        
        _spawnAsteroidsRoutine = StartCoroutine(_respawn.SpawnAsteroids(_player, _timeRespawnAsteroids));
        _spawnUFORoutine = StartCoroutine(_respawn.SpawnUFO(_ufo, _player, _timeRespawnUFO));
        
        BigAsteroidDestruction.OnAsteroidDestruction.AddListener(LaunchChips);
        EventManager.OnSmallAsteroidDistruction.AddListener(RemoveActiveAsteroids);
    }

    public void StopSpawner()
    {
        StopCoroutine(_spawnAsteroidsRoutine);
        StopCoroutine(_spawnUFORoutine);
    }

    private void RemoveActiveAsteroids()
    {
        _respawn.RemoveActiveAsteroids();
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

        for (int i = 0; i < _amountAsteroids * _respawn.AmountChips * 2; i++)
        {
            var asteroid = Instantiate(_smallAsteroidPrefab, _cask);
            _respawn.SmallAsteroids.Add(asteroid);
            asteroid.gameObject.SetActive(false);
        }
    }
}
