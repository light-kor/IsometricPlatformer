using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class LaserGun : MonoBehaviour
{
    public UnityAction<float> ChargeChanged;

    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LineRenderer _lineRenderer;

    [Header("Settings")]
    [SerializeField] private float _workTime = 1.5f;
    [SerializeField] private float _cooldownTime = 10f;
    [SerializeField] private float _damage;

    private Coroutine _coroutine;
    private bool _using;
    private Turret _buffer;
    private Collider _lastTarget;

    private const float MaxLaserRange = 50f;

    private void Start()
    {
        InputSystem.Input.Player.LaserShot.performed += ctx => TryStartShooting();
        ResetGame.ResetLevel += ResetGun;
        _lineRenderer.positionCount = 2;
        ResetGun();
    }

    private void TryStartShooting()
    {
        if (_using == false)
            _coroutine = StartCoroutine(ShootingCycle());
    }

    private void Shoot()
    {
        Vector3 target;

        Ray ray = new Ray(transform.position, transform.forward);
        //Debug.DrawRay(pos, transform.forward * 100, Color.yellow);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            target = hit.point;

            if (hit.collider == _lastTarget)
            {
                _buffer.TakeDamage(_damage / 30);
            }
            else if (hit.collider.gameObject.TryGetComponent(out Turret turret))
            {
                _lastTarget = hit.collider;
                _buffer = turret;
            }
        }
        else
            target = transform.forward * MaxLaserRange;

        _lineRenderer.SetPosition(0, _shootPoint.position);
        _lineRenderer.SetPosition(1, target);
    }

    private IEnumerator ShootingCycle()
    {
        _lineRenderer.enabled = true;
        _using = true;

        float progress = 0f;

        while (progress < 1f)
        {
            progress += Time.deltaTime / _workTime;
            Shoot();
            ChargeChanged?.Invoke(1 - progress);
            yield return null;
        }

        _lineRenderer.enabled = false;
        progress = 0f;

        while (progress < 1f)
        {
            progress += Time.deltaTime / _cooldownTime;
            ChargeChanged?.Invoke(progress);
            yield return null;
        }

        _using = false;
    }

    private void ResetGun()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _lineRenderer.enabled = false;
        _using = false;
        ChargeChanged?.Invoke(1f);
    }

    private void OnDestroy()
    {
        ResetGame.ResetLevel -= ResetGun;
    }
}
