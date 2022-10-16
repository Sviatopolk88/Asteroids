using UnityEngine;

public class UFO_Destruction : MonoBehaviour, IHittable
{
    private int _points = 30;
    public void HitObject()
    {
        EventManager.SendAddPoints(_points);
        this.gameObject.SetActive(false);
    }
}
