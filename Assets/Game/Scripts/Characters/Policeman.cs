using System.Collections;

namespace Game.Scripts.Characters
{
    public class Policeman : Character
    {
        private void Shot()
        {
            animator.SetTrigger("IsShooting");
        }
        public override IEnumerator Attack(Character attackedCharacter)
        {
            Shot();
            yield return Waiter.WaitAnimation(animator);

            attackedCharacter.TakeDamage();
            attackedCharacter.Die();
        }
    }
}