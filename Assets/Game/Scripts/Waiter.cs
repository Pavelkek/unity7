using System.Collections;
using UnityEngine;

namespace Game.Scripts
{
    public static class Waiter
    {
        public static IEnumerator WaitNextFrame()
        {
            yield return null;
        }

        public static IEnumerator WaitAnimation(Animator animator)
        {
            yield return WaitNextFrame();
            
            var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            var duration = animatorStateInfo.length;

            yield return new WaitForSeconds(duration);
        }
    }
}