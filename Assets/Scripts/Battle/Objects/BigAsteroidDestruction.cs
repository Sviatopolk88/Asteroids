using UnityEngine;

public class BigAsteroidDestruction : MonoBehaviour, IHittable
{
    private int _points = 5;
    public void HitObject()
    {
        this.gameObject.SetActive(false);
    }
}
