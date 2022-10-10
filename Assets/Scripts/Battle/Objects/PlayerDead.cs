using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hitObject = collision.gameObject.GetComponent<IHittable>();
        if (hitObject != null)
        {
            Debug.Log("Game over");
        }
    }
}
