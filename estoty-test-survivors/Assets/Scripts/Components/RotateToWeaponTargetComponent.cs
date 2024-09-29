using System.Collections;
using UnityEngine;

namespace estoty_test
{
    public class RotateToWeaponTargetComponent : BaseComponent
    {
        public Transform Target;
        public HolsterComponent HolsterComponent;
        public Rigidbody2D Rigidbody;

        private DamagableComponent CurrentTarget => HolsterComponent.CurrentWeapon.CurrentTarget;

        private IEnumerator Rotate()
        {
            while (true)
            {
                if (Target == null || HolsterComponent == null)
                {
                    yield return null;
                    continue;
                }

                Quaternion rotation = Target.rotation;

                if (HolsterComponent.CurrentWeapon != null && CurrentTarget != null)
                {
                    Vector2 dir = (CurrentTarget.transform.position - Target.position).normalized;

                    if (dir.x < 0)
                        rotation = Quaternion.Euler(0, -180, 0);
                    else
                        rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (Rigidbody != null)
                {
                    if (Rigidbody.velocity.x < 0)
                        rotation = Quaternion.Euler(0, -180, 0);
                    else
                        rotation = Quaternion.Euler(0, 0, 0);
                }

                Target.rotation = rotation;

                yield return new WaitForSeconds(0.1f);
            }
        }

        private void Start()
        {
            StartCoroutine(Rotate());
        }

        public override void Dispose()
        {
            Destroy(this);
        }
    }
}
