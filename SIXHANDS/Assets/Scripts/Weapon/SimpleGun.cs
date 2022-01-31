using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class SimpleGun : MonoBehaviour
{
    public UnityAction<int> AmmoInClip;
    public UnityAction Reload;

    [SerializeField] private Transform _shootPoint;
    [SerializeField] private BulletContainer _bullets;

    [Header("Settings")]
    [SerializeField] private int _maxAmmo;
    [SerializeField] private float _reloadTime;

    private Sequence _sequence;
    private int _ammo;
    private bool _canShoot;

    private void Start()
    {
        InputSystem.Input.Player.SimpleShot.performed += ctx => Shoot();
        ResetGame.ResetLevel += ResetGun;

        ResetGun();
    }

    private void Shoot()
    {
        if (_canShoot)
        {
            _bullets.ReleaseBullet(_shootPoint.position, transform.forward);
            _ammo--;
            AmmoInClip?.Invoke(_ammo);

            if (_ammo == 0)
            {
                _canShoot = false;
                ReloadGun();
            }
        }
    } 

    private void ReloadGun()
    {
        _sequence = DOTween.Sequence();
        _sequence.AppendInterval(_reloadTime);
        _sequence.AppendCallback(() => ResetGun());
    }

    private void ResetGun()
    {
        _canShoot = true;
        _ammo = _maxAmmo;
        Reload?.Invoke();
    }

    private void OnDestroy()
    {
        ResetGame.ResetLevel -= ResetGun;
    }
}
