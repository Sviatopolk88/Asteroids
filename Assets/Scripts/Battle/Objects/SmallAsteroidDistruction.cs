using UnityEngine;

public class SmallAsteroidDistruction : MonoBehaviour, IHittable
{
    private int _points = 10;
    public void HitObject()
    {
        EventManager.SendAddPoints(_points);
        EventManager.SendSmallAsteroidDistruction();
        this.gameObject.SetActive(false);
    }
}
