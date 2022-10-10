using System.Collections.Generic;
using UnityEngine;

public class ShootingLogic
{
    public int AvailableLaserCharges => _laserCharges;
    public int MaxLasers => _lasers.Count;

    private int _maxBullets => _bullets.Count;

    private List<Transform> _bullets;
    private List<Transform> _lasers;
    private int _indexBul;
    private int _indexLaser;
    private int _laserCharges = 2;

    public ShootingLogic(List<Transform> bullets, List<Transform> lasers)
    {
        _bullets = bullets;
        _lasers = lasers;
    }

    public void ShootBullet(Transform player)
    {
        var bullet = _bullets[_indexBul];
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
        if (AvailableLaserCharges == 0)
        {
            return;
        }

        var laser = _lasers[_indexLaser];
        Shoot(laser, player);

        if (_indexLaser < MaxLasers - 1)
        {
            _indexLaser++;
        }
        else
        {
            _indexLaser = 0;
        }

        _laserCharges--;
    }

    public void RechargeLaser()
    {
        _laserCharges++;
    }

    public void Shoot(Transform shell, Transform player)
    {
        shell.gameObject.SetActive(true);
        shell.transform.position = player.position;
        shell.GetComponent<ShellHittableBase>().Shoot(player.rotation.eulerAngles);
    }
}
