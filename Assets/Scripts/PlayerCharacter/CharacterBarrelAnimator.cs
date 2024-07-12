using MIG.API;
using MIG.Extensions;
using UnityEngine;

namespace MIG.PlayerCharacter
{
    public sealed class CharacterBarrelAnimator : AbstractCharacterAnimator
    {
        [SerializeField]
        [CheckObject]
        private GameObject _wholeBarrelGameObject;

        [SerializeField]
        [CheckObject]
        private GameObject _brokenBarrelGameObject;

        [SerializeField]
        [CheckObject]
        private Animator _wholeBarrelAnimator;

        [SerializeField]
        private AnimatorHash _speedFloatHash;

        [SerializeField]
        private AnimatorHash _directionFloatHash;

        public override void SetSpeed(float speed)
            => _wholeBarrelAnimator.SetFloat(_speedFloatHash, speed);

        public override void SetDirection(float direction)
            => _wholeBarrelAnimator.SetFloat(_directionFloatHash, direction);

        public override void PlaySuccessAnim()
        {
            _wholeBarrelGameObject.Deactivate();
            _brokenBarrelGameObject.Activate();
        }

        public override void PlayFailureAnim()
        {
            _wholeBarrelGameObject.Deactivate();
            _brokenBarrelGameObject.Activate();
        }
    }
}