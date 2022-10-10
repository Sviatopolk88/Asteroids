using UnityEngine;

public class ShellHittableBullets : ShellHittableBase
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        this.gameObject.SetActive(false);
    }
}
