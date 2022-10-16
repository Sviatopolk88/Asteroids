using System.Collections.Generic;
using UnityEngine;

public class ShootingLogic
{
    public List<Transform> Bullets { get; set; } = new();
    public List<Transform> LaserCharges { get; set; } = new();

    private int _maxBullets => Bullets.Count;

    private int _indexBul;
    private int _indexLaser;

    public void ShootBullet(Transform player)
    {
        var bullet = Bullets[_indexBul];
        Shoot(bullet, player);

        if (_indexBul < _maxBullets - 1)
        {
            _indexBul++;
        }
        else
        {
            _indexBul = 0;
        }
    }
    
    public void ShootLaser(Transform player)
    {
        var laser = LaserCharges[_indexLaser];
        Shoot(laser, player);

        if (_indexLaser < LaserCharges.Count - 1)
        {
            _indexLaser++;
        }
        else
        {
            _indexLaser = 0;
        }
    }
    
    public void Shoot(Transform shell, Transform player)
    {
        shell.gameObject.SetActive(true);
        shell.transform.position = player.position;
        shell.GetComponent<ShellHittableBase>().Shoot(player.rotation.eulerAngles);
    }
}
