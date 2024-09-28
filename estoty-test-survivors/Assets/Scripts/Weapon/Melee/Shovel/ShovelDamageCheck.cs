using System;
using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Collider2D))]
    public class ShovelDamageCheck : MonoBehaviour
    {
        public Action<DamagableComponent> OnDamage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent<DamagableComponent>(out var dComponent))
                return;

            OnDamage?.Invoke(dComponent);
        }
    }
}
