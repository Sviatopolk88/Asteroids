using UnityEngine;

public class ShellHittableBase : MonoBehaviour
{
    public void Shoot(Vector3 direction)
    {
        transform.rotation = Quaternion.Euler(direction);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hitObject = collision.gameObject.GetComponent<IHittable>();
        if (hitObject != null)
        {
            hitObject.HitObject();
        }
    }
}
