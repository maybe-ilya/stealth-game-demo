using MIG.API;
using UnityEngine;

namespace MIG.PlayerCharacter
{
    public sealed class CompositeCharacterAnimator : AbstractCharacterAnimator
    {
        [SerializeField]
        [CheckObject]
        private AbstractCharacterAnimator[] _characterAnimators;

        public override void SetSpeed(float speed)
        {
            foreach (var animator in _characterAnimators)
            {
                animator.SetSpeed(speed);
            }
        }

        public override void SetDirection(float direction)
        {
            foreach (var animator in _characterAnimators)
            {
                animator.SetDirection(direction);
            }
        }

        public override void PlaySuccessAnim()
        {
            foreach (var animator in _characterAnimators)
            {
                animator.PlaySuccessAnim();
            }
        }

        public override void PlayFailureAnim()
        {
            foreach (var animator in _characterAnimators)
            {
                animator.PlayFailureAnim();
            }
        }
    }
}