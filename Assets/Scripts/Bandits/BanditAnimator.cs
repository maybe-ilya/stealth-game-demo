using MIG.API;
using UnityEngine;

namespace MIG.Bandits
{
    public sealed class BanditAnimator : MonoBehaviour
    {
        [SerializeField]
        [CheckObject]
        private Animator _animator;

        [SerializeField]
        private AnimatorHash _speedFloatHash;

        [SerializeField]
        private AnimatorHash _shootTrigHash;

        public void SetSpeed(float speed)
            => _animator.SetFloat(_speedFloatHash, speed);

        public void PlayShootAnim()
            => _animator.SetTrigger(_shootTrigHash);
    }
}