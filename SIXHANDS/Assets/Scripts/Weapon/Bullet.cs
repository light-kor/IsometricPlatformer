using UnityEngine;

namespace Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxLifeTime;
        public float Damage => _damage;
        private Vector3 _direction;
        private float _lifeTime;
        private float _damage;
        
        private void Update()
        {
            transform.Translate(_speed * Time.deltaTime * _direction);

            _lifeTime += Time.deltaTime;

            if (_lifeTime > _maxLifeTime)
                ResetBullet();
        }

        public void InitBullet(Vector3 pos, Vector3 dir, float damage)
        {
            transform.position = pos;
            _direction = dir;
            _damage = damage;
        }

        public void ResetBullet()
        {
            _lifeTime = 0f;
            gameObject.SetActive(false);
        }
    }
}
