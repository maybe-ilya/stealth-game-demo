using System;
using MIG.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace MIG.Player.Impl
{
    public sealed class DefaultInputHandler :
        IMultiModePlayerInputHandler,
        PlayerControls.IGameplayActions
    {
        private PlayerControls _playerControls;
        private InputSystemUIInputModule _inputModule;

        public event Action<Vector2> OnMove;

        public DefaultInputHandler(InputSystemUIInputModule inputModule)
        {
            _playerControls = new PlayerControls();
            _inputModule = inputModule;
            SetupGameplayScheme();
            SetupUIScheme();
        }

        public void SetGameInputMode()
        {
            _playerControls.UI.Disable();
            _playerControls.Gameplay.Enable();
        }

        public void SetUIInputMode()
        {
            _playerControls.Gameplay.Disable();
            _playerControls.UI.Enable();
        }

        private void SetupGameplayScheme()
        {
            _playerControls.Gameplay.SetCallbacks(this);
        }

        private void SetupUIScheme()
        {
            var uiActions = _playerControls.UI;
            _inputModule.UnassignActions();

            _inputModule.submit = uiActions.Submit.GetActionReference();
            _inputModule.cancel = uiActions.Cancel.GetActionReference();
            _inputModule.move = uiActions.Navigate.GetActionReference();
            _inputModule.leftClick = uiActions.Click.GetActionReference();
            _inputModule.point = uiActions.Point.GetActionReference();
            _inputModule.scrollWheel = uiActions.ScrollWheel.GetActionReference();
        }

        void PlayerControls.IGameplayActions.OnMove(InputAction.CallbackContext context)
        {
            OnMove?.Invoke(context.ReadValue<Vector2>());
        }
    }
}