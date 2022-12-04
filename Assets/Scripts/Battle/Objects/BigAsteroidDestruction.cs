using UnityEngine;
using UnityEngine.Events;

public class BigAsteroidDestruction : MonoBehaviour, IHittable
{
    public static UnityEvent<Vector2> OnAsteroidDestruction = new UnityEvent<Vector2>();
    
    [SerializeField] private int _points = 5;
    public void HitObject()
    {
        OnAsteroidDestruction.Invoke(this.transform.position);
        EventManager.SendAddPoints(_points);
        SoundManager.Instance.AsteroidExplosion();
        this.gameObject.SetActive(false);
    }
}
