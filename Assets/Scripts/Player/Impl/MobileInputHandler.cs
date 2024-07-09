using System;
using UnityEngine;

namespace MIG.Player
{
    public sealed class MobileInputHandler : IMultiModePlayerInputHandler
    {
        private readonly IMultiModePlayerInputHandler _baseInputHandler;
        private readonly IMobileInputUIPanel _mobileInputPanel;

        public MobileInputHandler(
            IMultiModePlayerInputHandler baseInputHandler,
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

        public void SetGameInputMode()
        {
            _baseInputHandler.SetGameInputMode();
            _mobileInputPanel.Activate();
        }

        public void SetUIInputMode()
        {
            _mobileInputPanel.Deactivate();
            _baseInputHandler.SetUIInputMode();
        }
    }
}