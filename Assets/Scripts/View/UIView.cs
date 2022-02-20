using System;
using UnityEngine;
using UnityEngine.UI;


namespace BomberPig
{
    public sealed class UIView : MonoBehaviour
    {
        public event Action OnPressRestartButton = delegate { };

        [SerializeField] private EndGamePanelView _endGamePanel;
        [SerializeField] private InfoPanelView _infoPanel;


        private void OnEnable()
        {
            _endGamePanel.GetRestartButton.onClick.AddListener(Restart);
        }

        private void OnDisable()
        {
            _endGamePanel.GetRestartButton.onClick.RemoveListener(Restart);
        }

        public void EndGamePanelActivation(bool isActive)
        {
            _endGamePanel.gameObject.SetActive(isActive);
        }

        public void ShowBombCooldownTime(float time)
        {
            _infoPanel.SetFillAmount(time);
        }

        public void ShowScoreText(int score)
        {
            _infoPanel.SetScoreText(score);
        }

        private void Restart()
        {
            OnPressRestartButton.Invoke();
        }
    }
}
