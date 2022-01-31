using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxLifeTime;

    private Vector3 _direction = Vector3.forward;
    private float _lifeTime = 0f;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);

        _lifeTime += Time.deltaTime;

        if (_lifeTime > _maxLifeTime)
            ResetBullet();
    }

    public void SetTransform(Vector3 pos, Vector3 dir)
    {
        transform.position = pos;
        _direction = dir;
    }

    public void ResetBullet()
    {
        _lifeTime = 0f;
        gameObject.SetActive(false);
    }
}
