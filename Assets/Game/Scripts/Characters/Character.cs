using UnityEngine;
using System.Collections;

namespace Game.Scripts.Characters
{
    public abstract class Character : MonoBehaviour
    {
        public int health;
        [SerializeField]
        protected Animator animator;

        public void TakeDamage()
        {
            health -= 1;
        }

        public void Die()
        {
            if (health <= 0)
            {
                Debug.Log($"{GetType().Name}.Die: {gameObject.name}");
            }
        }

        public abstract IEnumerator Attack(Character attackedCharacter);
    }
}