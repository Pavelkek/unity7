using System;
using System.Collections;
using UnityEngine;

namespace Game.Scripts.Characters
{
    public class Gangster : Character
    {
        public float startPoint;
        private IEnumerator HittingOn()
        {
            yield return Waiter.WaitAnimation(animator);
            animator.SetBool("IsHitting", true);
        }
        
        private IEnumerator HittingOff()
        {            
            yield return Waiter.WaitAnimation(animator);
            animator.SetBool("IsHitting", false);
        }
        
        private void RunningOn()
        {
            animator.SetBool("IsRunning", true);
        }
        
        private void RunningOff()
        {
            animator.SetBool("IsRunning", false);
        }
        
        private void MoveWithSpeed(float speed)
        {
            transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
        }
        
        private void RotateWithSpeed(float rotateDirection)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + rotateDirection * Time.deltaTime, transform.eulerAngles.z);
        }

        private IEnumerator MoveToAim()
        {
            RunningOn();
            while (transform.position.z > -26.5)
            {
                MoveWithSpeed(2f);
                yield return Waiter.WaitNextFrame();
            }
            RunningOff();
        }
        
        private IEnumerator MoveToStartPoint()
        {
            var delta = 1f;
            while (Math.Abs(transform.eulerAngles.y - 0f) > delta)
            {
                RotateWithSpeed(-100f);
                yield return Waiter.WaitNextFrame();
            }
            RunningOn();
            while (transform.position.z < startPoint)
            {
                MoveWithSpeed(2f);
                yield return Waiter.WaitNextFrame();
            }
            RunningOff();
            yield return Waiter.WaitAnimation(animator);
            while (Math.Abs(transform.eulerAngles.y - 180f) > delta)
            {
                RotateWithSpeed(100f);
                yield return Waiter.WaitNextFrame();
            }
        }
        public override IEnumerator Attack(Character attackedCharacter)
        {
            yield return MoveToAim();
            yield return HittingOn();
            yield return HittingOff();
            attackedCharacter.TakeDamage();
            attackedCharacter.Die();
            yield return MoveToStartPoint();
        }
    }
}