using System;
using UnityEngine;
using UnityEngine.UI;


namespace BomberPig
{
    public sealed class UIView : MonoBehaviour
    {
        public event Action OnPressRestartButton = delegate { };

        [SerializeField] private EndGamePanelView _endGamePanel;


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

        private void Restart()
        {
            OnPressRestartButton.Invoke();
        }
    }
}
