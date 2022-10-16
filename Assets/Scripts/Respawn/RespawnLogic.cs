using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLogic
{
    public List<Transform> BigAsteroids = new();
    public List<Transform> SmallAsteroids = new();

    public int AmountAsteroids => BigAsteroids.Count;
    public int IndexBigAsteroid
    {
        get
        {
            return _indexBigAsteroid;
        }
        private set
        {
            if (value < AmountAsteroids)
            {
                _indexBigAsteroid = value;
                return;
            }
            _indexBigAsteroid = 0;
        }
    }
    public int IndexSmallAsteroid
    {
        get
        {
            return _indexSmallAsteroid;
        }
        private set
        {
            if (value < SmallAsteroids.Count)
            {
                _indexSmallAsteroid = value;
                return;
            }
            _indexSmallAsteroid = 0;
        }
    }

    [SerializeField] private int _amountRespawnAsteroids = 3;

    private float _borderY => Camera.main.orthographicSize;
    private float _borderX => Camera.main.aspect * _borderY;

    private int _amountChips = 3;
    private int _indexBigAsteroid;
    private int _indexSmallAsteroid;
    private int _amountActiveAsteroids;

    public IEnumerator SpawnAsteroids(Transform player, float timeRespawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeRespawn);
            if (_amountActiveAsteroids < 12)
            {
                RespawnAsteroid(player, _amountRespawnAsteroids);
            }
        }
    }

    public IEnumerator SpawnUFO(Transform ufo, Transform player, float timeRespawn)
    {
        while (true)
        {
        yield return new WaitForSeconds(timeRespawn);
            if (!ufo.gameObject.activeInHierarchy)
            {
                ufo.gameObject.SetActive(true);
                SetPosition(ufo, player);
                Debug.Log(ufo.position);
            }
        }
    }

    public void RespawnAsteroid(Transform player, int amountAsteroids)
    {
        var correctIndex = IndexBigAsteroid + amountAsteroids < AmountAsteroids;
        var numberAsteroids = correctIndex ? IndexBigAsteroid + amountAsteroids : AmountAsteroids;
        for (int i = IndexBigAsteroid; i < numberAsteroids; i++)
        {
            var asteroid = BigAsteroids[i];
            asteroid.gameObject.SetActive(true);
            SetPosition(asteroid, player);
            _amountActiveAsteroids++;
            IndexBigAsteroid++;
        }
    }

    public void LaunchSmallAsteroids(Vector2 startPosition)
    {
        _amountActiveAsteroids--;
        var numberAsteroids = IndexSmallAsteroid + _amountChips;
        for (int i = IndexSmallAsteroid; i < numberAsteroids; i++)
        {
            var asteroid = SmallAsteroids[i];
            asteroid.transform.position = startPosition;
            asteroid.transform.Rotate(0, 0, Random.Range(0, 360));
            asteroid.gameObject.SetActive(true);
            IndexSmallAsteroid++;
        }
    }

    private void SetPosition(Transform enemy, Transform player)
    {
        var playerPosition = player.transform.position;
        bool check = false;

        while (check == false)
        {
            float enemyX = Random.Range(-_borderX, _borderX);
            float enemyY = Random.Range(-_borderY, _borderY);

            if (enemyX < 3.5 - _borderX || enemyX > _borderX - 3.5)
            {
                enemy.position = new Vector2(enemyX, enemyY);
            }
            else if (enemyY < 2.5 - _borderY || enemyY > _borderY - 2.5)
            {
                enemy.position = new Vector2(enemyX, enemyY);
            }
            else
            {
                continue;
            }

            if (Mathf.Abs(enemy.position.x - playerPosition.x) > 3.5 || Mathf.Abs(enemy.position.y - playerPosition.y) > 2.5)
            {
                check = true;
            }
        }
    }
}
