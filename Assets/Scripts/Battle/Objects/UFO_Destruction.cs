using UnityEngine;

public class UFO_Destruction : MonoBehaviour, IHittable
{
    private int _points = 30;
    public void HitObject()
    {
        this.gameObject.SetActive(false);
    }
}
