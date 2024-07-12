using System;
using MIG.API;
using UnityEngine;

namespace MIG.PlayerCharacter
{
    public sealed class DefaultCharacterAnimator : AbstractCharacterAnimator
    {
        [SerializeField]
        [CheckObject]
        private Animator _animator;

        [SerializeField]
        private AnimatorHash _speedFloatHash;

        [SerializeField]
        private AnimatorHash _directionFloatHash;

        [SerializeField]
        private AnimatorHash _successTrigHash;

        [SerializeField]
        private AnimatorHash _failureTrigHash;

        public override void SetSpeed(float speed)
            => _animator.SetFloat(_speedFloatHash, speed);

        public override void SetDirection(float direction)
            => _animator.SetFloat(_directionFloatHash, direction);

        public override void PlaySuccessAnim()
            => _animator.SetTrigger(_successTrigHash);

        public override void PlayFailureAnim()
            => _animator.SetTrigger(_failureTrigHash);
    }
}