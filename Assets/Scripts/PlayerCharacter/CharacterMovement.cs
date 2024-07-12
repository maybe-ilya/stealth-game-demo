using System;
using MIG.API;
using Unity.Mathematics;
using UnityEngine;

namespace MIG.PlayerCharacter
{
    public enum CharacterMoveState
    {
        None = 0,
        Idle = 1,
        Moving = 2,
    }

    [RequireComponent(typeof(CharacterController))]
    public sealed class CharacterMovement : MonoBehaviour
    {
        private static readonly Vector3 GRAVITY_VECTOR = new(0.0f, -9.81f, 0.0f);

        [Header("Move Properties")]
        [SerializeField]
        [Min(0.0f)]
        private float _moveMaxSpeed;

        [SerializeField]
        [Min(0.0f)]
        private float _moveAcceleration;

        [SerializeField]
        [Min(0.0f)]
        private float _moveDrag;

        [SerializeField]
        [Min(0.0f)]
        private float _moveStateSpeedTreshold;

        [Header("Turn Properties")]
        [SerializeField]
        [Min(0.0f)]
        private float _turnMaxSpeed;

        [SerializeField]
        [Min(0.0f)]
        private float _turnAcceleration;

        [SerializeField]
        [Min(0.0f)]
        private float _turnDrag;

        [Header("Dependencies")]
        [SerializeField]
        [CheckObject]
        private CharacterController _characterController;

        [SerializeField]
        [CheckObject]
        private Transform _cachedTransform;

        private float _currentMoveSpeed, _currentTurnSpeed;
        private CharacterMoveState _moveState;
        private float _moveInput, _turnInput;
        private float _moveAmount, _turnAmount, _moveDirectionSign, _turnDirectionSign;

        public event Action<CharacterMoveState> OnMoveStateChanged;
        public float CurrentSpeed => _currentMoveSpeed;
        public float MaxSpeed => _moveMaxSpeed;
        public float CurrentDirection => _moveDirectionSign;

        public void ApplyMoveInput(Vector2 input)
        {
            var moveInput = input.y;
            var turnInput = input.x;
            _moveAmount = math.abs(moveInput);
            _turnAmount = math.abs(turnInput);
            _moveDirectionSign = math.abs(moveInput) > math.EPSILON ? math.sign(moveInput) : _moveDirectionSign;
            _turnDirectionSign = math.abs(turnInput) > math.EPSILON ? math.sign(turnInput) : _turnDirectionSign;
        }

        public void Stop()
        {
            _moveAmount = 0;
            _moveDirectionSign = 0;
            _turnAmount = 0;
            _turnDirectionSign = 0;
            _currentMoveSpeed = 0;
            _currentTurnSpeed = 0;
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            ProcessMove(deltaTime);
            ProcessTurn(deltaTime);
        }

        private void ProcessMove(float deltaTime)
        {
            _currentMoveSpeed += (_moveAcceleration * _moveAmount - _moveDrag) * deltaTime;
            _currentMoveSpeed = math.clamp(_currentMoveSpeed, 0.0f, _moveMaxSpeed);

            var newMoveState = _currentMoveSpeed > _moveStateSpeedTreshold
                ? CharacterMoveState.Moving
                : CharacterMoveState.Idle;
            if (newMoveState != _moveState)
            {
                _moveState = newMoveState;
                OnMoveStateChanged?.Invoke(_moveState);
            }

            var moveDelta = _currentMoveSpeed * _moveDirectionSign * deltaTime * _cachedTransform.forward +
                            GRAVITY_VECTOR * deltaTime;
            _characterController.Move(moveDelta);
        }

        private void ProcessTurn(float deltaTime)
        {
            _currentTurnSpeed += (_turnAcceleration * _turnAmount - _turnDrag) * deltaTime;
            _currentTurnSpeed = math.clamp(_currentTurnSpeed, 0.0f, _turnMaxSpeed);

            var turnDelta = _currentTurnSpeed * _turnDirectionSign * deltaTime * Vector3.up;
            _cachedTransform.rotation = Quaternion.Euler(_cachedTransform.rotation.eulerAngles + turnDelta);
        }

#if UNITY_EDITOR
        private void Reset()
        {
            _cachedTransform = transform;
            _characterController = GetComponent<CharacterController>();
        }
#endif
    }
}