using System;
using MIG.API;
using MIG.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MIG.UI.Windows
{
    public sealed class GameOverWindow : AbstractWindow, IGameOverWindow
    {
        [SerializeField]
        [CheckObject]
        private GameObject _winMessageObject;

        [SerializeField]
        [CheckObject]
        private GameObject _loseMessageObject;

        [SerializeField]
        [CheckObject]
        private TMP_Text _timeLabel;

        [SerializeField]
        [CheckObject]
        private Button _retryButton;

        [SerializeField]
        [CheckObject]
        private Button _quitButton;

        private string _timeMessageFormat;

        public event Action OnRetryClicked;
        public event Action OnExitClicked;

        public void Setup(string timeMessageFormat)
        {
            _timeMessageFormat = timeMessageFormat;
        }

        public void SetData(GameOverWindowData input)
        {
            if (input.IsSuccessful)
            {
                _winMessageObject.Activate();
                _loseMessageObject.Deactivate();
            }
            else
            {
                _loseMessageObject.Activate();
                _winMessageObject.Deactivate();
            }

            _timeLabel.text = string.Format(_timeMessageFormat, input.ElapsedTime.TotalSeconds.ToString("F1"));
        }

        protected override void BeforeOpen()
        {
            _retryButton.onClick.AddListener(OnRetryButtonClick);
            _quitButton.onClick.AddListener(OnExitButtonClicked);
        }

        protected override void BeforeClose()
        {
            _retryButton.onClick.RemoveListener(OnRetryButtonClick);
            _quitButton.onClick.RemoveListener(OnExitButtonClicked);
        }

        private void OnRetryButtonClick()
            => OnRetryClicked?.Invoke();

        private void OnExitButtonClicked()
            => OnExitClicked?.Invoke();
    }
}