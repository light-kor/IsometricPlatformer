using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletContainer : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _bulletCount;

    private List<Bullet> _pool = new List<Bullet>();

    private void Start()
    {
        InstantiateBullets(_bulletPrefab, _bulletCount);
    }

    private void InstantiateBullets(Bullet prefab, int maxCount)
    {
        for (int i = 0; i < maxCount; i++)
        {
            Bullet spawnedBullet = Instantiate(prefab, transform);
            spawnedBullet.gameObject.SetActive(false);
            _pool.Add(spawnedBullet);
        }
    }

    private bool TryGetBullet(out Bullet result)
    {
        result = _pool.First(p => p.gameObject.activeSelf == false);
        return result != null;
    }

    public void ReleaseBullet(Vector3 position, Vector3 direction)
    {
        if (TryGetBullet(out Bullet bullet))
        {
            bullet.gameObject.SetActive(true);
            bullet.SetTransform(position, direction);
        }
    }
}
