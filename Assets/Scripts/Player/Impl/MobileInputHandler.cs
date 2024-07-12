using System;
using UnityEngine;

namespace MIG.Player
{
    public sealed class MobileInputHandler : IActivatablePlayerInputHandler
    {
        private readonly IActivatablePlayerInputHandler _baseInputHandler;
        private readonly IMobileInputUIPanel _mobileInputPanel;

        public MobileInputHandler(
            IActivatablePlayerInputHandler baseInputHandler,
            IMobileInputUIPanel mobileInputPanel
        )
        {
            _baseInputHandler = baseInputHandler;
            _mobileInputPanel = mobileInputPanel;
        }

        public event Action<Vector2> OnMove
        {
            add => _baseInputHandler.OnMove += value;
            remove => _baseInputHandler.OnMove -= value;
        }

        public void Activate()
        {
            _baseInputHandler.Activate();
            _mobileInputPanel.Activate();
        }

        public void Deactivate()
        {
            _mobileInputPanel.Deactivate();
            _baseInputHandler.Deactivate();
        }
    }
}