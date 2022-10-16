using UnityEngine;

public class ShellHittableBullets : ShellHittableBase
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag != "Player")
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
