using MIG.API;
using MIG.GameActors;
using UnityEngine;

namespace MIG.PlayerCharacter
{
    [RequireComponent(typeof(CharacterMovement))]
    [RequireComponent(typeof(CharacterVisibilityAgent))]
    public sealed class Character :
        MonoBehaviour,
        IPlayerPawn,
        IPlayerCharacter,
        IDestroyableActor
    {
        [SerializeField]
        [CheckObject]
        private CharacterMovement _characterMovement;

        [SerializeField]
        [CheckObject]
        private CharacterVisibilityAgent _characterVisibilityAgent;

        [SerializeField]
        [CheckObject]
        private AbstractCharacterAnimator _characterAnimator;

        private IPlayerInputHandler _inputHandler;

        public int Id { get; set; }

        public Transform Transform => transform;

        public void Win()
        {
            _characterMovement.Stop();
            _characterAnimator.PlaySuccessAnim();
        }

        public void Lose()
        {
            _characterMovement.Stop();
            _characterAnimator.PlayFailureAnim();
        }

        public void SetupInput(IPlayerInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            _inputHandler.OnMove += OnMoveInput;
        }

        public void ClearInputs()
        {
            _inputHandler.OnMove -= OnMoveInput;
            _inputHandler = null;
        }

        private void Update()
        {
            _characterAnimator.SetSpeed(_characterMovement.CurrentSpeed / _characterMovement.MaxSpeed);
            _characterAnimator.SetDirection(_characterMovement.CurrentDirection);
        }

        private void OnEnable()
        {
            _characterMovement.OnMoveStateChanged += OnMoveStateChanged;
        }

        private void OnDisable()
        {
            _characterMovement.OnMoveStateChanged -= OnMoveStateChanged;
        }

        private void OnMoveInput(Vector2 moveInput)
            => _characterMovement.ApplyMoveInput(moveInput);

        private void OnMoveStateChanged(CharacterMoveState moveState)
        {
            switch (moveState)
            {
                case CharacterMoveState.Idle:
                    _characterVisibilityAgent.MakeInvisible();
                    break;

                case CharacterMoveState.Moving:
                    _characterVisibilityAgent.MakeVisible();
                    break;
            }
        }

#if UNITY_EDITOR
        private void Reset()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _characterVisibilityAgent = GetComponent<CharacterVisibilityAgent>();
        }
#endif
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}