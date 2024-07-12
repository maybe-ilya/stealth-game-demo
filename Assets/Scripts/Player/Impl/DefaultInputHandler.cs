using System;
using MIG.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace MIG.Player.Impl
{
    public sealed class DefaultInputHandler :
        IActivatablePlayerInputHandler,
        PlayerControls.IGameplayActions
    {
        private PlayerControls _playerControls;
        private InputSystemUIInputModule _inputModule;

        public event Action<Vector2> OnMove;

        private PlayerControls.GameplayActions GameplayActions
            => _playerControls.Gameplay;

        private PlayerControls.UIActions UIActions
            => _playerControls.UI;

        public DefaultInputHandler(InputSystemUIInputModule inputModule)
        {
            _playerControls = new PlayerControls();
            _inputModule = inputModule;
            SetupGameplayActions();
            SetupUIActions();
            _playerControls.UI.Enable();
        }

        public void Activate()
            => GameplayActions.Enable();

        public void Deactivate()
            => GameplayActions.Disable();

        private void SetupGameplayActions()
            => GameplayActions.SetCallbacks(this);

        private void SetupUIActions()
        {
            _inputModule.UnassignActions();

            _inputModule.submit = UIActions.Submit.GetActionReference();
            _inputModule.cancel = UIActions.Cancel.GetActionReference();
            _inputModule.move = UIActions.Navigate.GetActionReference();
            _inputModule.leftClick = UIActions.Click.GetActionReference();
            _inputModule.point = UIActions.Point.GetActionReference();
            _inputModule.scrollWheel = UIActions.ScrollWheel.GetActionReference();
        }

        void PlayerControls.IGameplayActions.OnMove(InputAction.CallbackContext context)
            => OnMove?.Invoke(context.ReadValue<Vector2>());
    }
}