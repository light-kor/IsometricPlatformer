using System;
using Player;
using UnityEngine;

namespace Crystals
{
    [RequireComponent(typeof(Rigidbody))]
    public class Crystal : MonoBehaviour
    {
        public static Action<Crystal> CollectCrystal;
        [SerializeField] private Rigidbody _rigidbody;

        public void MoveToTarget(Vector3 target, float force)
        {
            var pos = Vector3.Lerp(transform.position, target, Time.deltaTime * force);
            _rigidbody.MovePosition(pos);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerStartPosition player))
            {
                CollectCrystal?.Invoke(this);
            }
        }
    }
}
