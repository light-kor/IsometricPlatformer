using UnityEngine;

namespace Turrets
{
    public class DestroyAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject _head;
        [SerializeField] private ParticleSystem _explosion;
        [SerializeField] private Turret _turret;

        private void Start()
        {
            _turret.TurnOnTurret += RestoreTurret;
            _turret.Destroyed += DestroyTurret;
        }

        private void DestroyTurret()
        {
            _head.SetActive(false);
            _explosion.Play();
        }

        private void RestoreTurret()
        {
            _head.SetActive(true);
            _explosion.Stop();
        }

        private void OnDestroy()
        {
            _turret.TurnOnTurret -= RestoreTurret;
            _turret.Destroyed -= DestroyTurret;
        }
    }
}
