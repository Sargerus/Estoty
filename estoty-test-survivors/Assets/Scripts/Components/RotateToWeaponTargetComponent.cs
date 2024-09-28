using UnityEngine;

namespace estoty_test
{
    public class RotateToWeaponTargetComponent : BaseComponent
    {
        public PlayerCharacter Character;
        public MeleeWeaponComponent MeleeWeaponComponent;
        public Rigidbody2D Rigidbody;

        private void Update()
        {
            if (Character == null)
                return;

            Quaternion rotation = Character.transform.rotation;

            if (MeleeWeaponComponent != null && MeleeWeaponComponent.View.CurrentTarget != null)
            {
                Vector2 dir = (MeleeWeaponComponent.View.CurrentTarget.transform.position - Character.transform.position).normalized;

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

            Character.transform.rotation = rotation;
        }

        public override void RemoveComponent()
        {
            Destroy(this);
        }
    }
}
