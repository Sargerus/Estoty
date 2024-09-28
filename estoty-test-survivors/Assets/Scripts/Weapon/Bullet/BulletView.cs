using System.Collections;
using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class BulletView : MonoBehaviour
    {
        private Rigidbody2D _rb;

        private float _damage;
        private Vector2 _velocity;
        private float _maxDistance;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Setup(float damage, Vector2 velocity, float maxDistance)
        {
            _damage = damage;
            _velocity = velocity;
            _maxDistance = maxDistance;
        }

        public void Fly()
        {
            _rb.velocity = _velocity;
            StartCoroutine(CheckDistance());
        }

        private IEnumerator CheckDistance()
        {
            Vector2 start = transform.position;

            while (Vector2.Distance(transform.position, start) < _maxDistance)
                yield return null;

            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent<DamagableComponent>(out var dComponent))
                return;

            dComponent.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
