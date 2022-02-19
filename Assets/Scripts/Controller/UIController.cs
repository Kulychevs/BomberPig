﻿using System;
using UnityEngine;


namespace BomberPig
{
    public sealed class UIController
    {
        public event Action OnRestart = delegate { };
        private readonly UIView _uiView;

        public UIController()
        {
            _uiView = GameObject.FindObjectOfType<UIView>();
            _uiView.OnPressRestartButton += Restart;
        }

        public void ActivateEndGamePanel()
        {
            _uiView.EndGamePanelActivation(true);
            Services.Instance.TimeService.SetTimeScale(0);
        }

        private void Restart()
        {
            OnRestart.Invoke();
            _uiView.EndGamePanelActivation(false);
            Services.Instance.TimeService.SetTimeScale(1);
        }
    }
}
