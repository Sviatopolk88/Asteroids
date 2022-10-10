using UnityEngine;

public class SmallAsteroidDistruction : MonoBehaviour, IHittable
{
    private int _points = 10;
    public void HitObject()
    {
        this.gameObject.SetActive(false);
    }
}
