using UnityEngine;

namespace MIG.PlayerCharacter
{
    public abstract class AbstractCharacterAnimator : MonoBehaviour
    {
        public abstract void SetSpeed(float speed);
        public abstract void SetDirection(float direction);
        public abstract void PlaySuccessAnim();
        public abstract void PlayFailureAnim();
    }
}