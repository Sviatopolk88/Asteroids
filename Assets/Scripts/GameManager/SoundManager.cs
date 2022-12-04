using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _laser;
    [SerializeField] private AudioSource _rocket;
    [SerializeField] private AudioSource _ufo;
    [SerializeField] private AudioSource _smallAsteroidExplosion;
    [SerializeField] private AudioSource _asteroidExplosion;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void LaserShot()
    {
        _laser.Play();
    }

    public void MoveUFO()
    {
        _ufo.Play();
    }

    public void DestroyUFO()
    {
        _ufo.Stop();
        _asteroidExplosion.Play();
    }

    public void AsteroidExplosion()
    {
        _asteroidExplosion.Play();
    }

    public void SmallAsteroidExplosion()
    {
        _smallAsteroidExplosion.Play();
    }

    public void RocketMove()
    {
        _rocket.Play();
    }

    public void RocketStop()
    {
        _rocket.Stop();
    }
}
