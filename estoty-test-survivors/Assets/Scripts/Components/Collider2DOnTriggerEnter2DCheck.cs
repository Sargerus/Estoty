using System;
using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Collider2D))]
    public class Collider2DOnTriggerEnter2DCheck : BaseComponent
    {
        public Collider2D Collider;
        public Action<DamagableComponent> OnDamage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent<DamagableComponent>(out var dComponent))
                return;

            OnDamage?.Invoke(dComponent);
        }

        public void EnableComponent(bool isEnabled)
        {
            Collider.enabled = isEnabled;
        }

        public override void Dispose()
        {
            Destroy(Collider);
            Destroy(this);
        }
    }
}
