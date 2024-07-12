using System;
using MIG.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MIG.UI.Windows
{
    public sealed class PlayerHUD : AbstractWindow, IPlayerHUD
    {
        [SerializeField]
        [CheckObject]
        private Image _timerProgressBar;

        [SerializeField]
        private Gradient _timerProgressBarGradient;

        [SerializeField]
        [CheckObject]
        private TMP_Text _timerLabel;

        [SerializeField]
        [CheckObject]
        private Button _replayButton;

        public event Action OnReplayClicked;

        public void SetTimerRatio(float ratio)
        {
            _timerProgressBar.fillAmount = ratio;
            _timerProgressBar.color = _timerProgressBarGradient.Evaluate(ratio);
        }

        public void SetTimerText(string timerText)
            => _timerLabel.text = timerText;

        protected override void BeforeOpen()
        {
            _replayButton.onClick.AddListener(OnReplayButtonClicked);
        }

        protected override void BeforeClose()
        {
            _replayButton.onClick.RemoveListener(OnReplayButtonClicked);
        }

        private void OnReplayButtonClicked()
            => OnReplayClicked?.Invoke();
    }
}