using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Crystal : MonoBehaviour
{
    private CrystalCollector _collector;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _collector = GetComponentInParent<CrystalCollector>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveToTarget(Vector3 target, float force)
    {
        Vector3 pos = Vector3.Lerp(transform.position, target, Time.deltaTime * force);
        _rigidbody.MovePosition(pos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _collector.Collect();
            gameObject.SetActive(false);
        }
    }
}
