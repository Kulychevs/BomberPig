using UnityEngine;


namespace BomberPig
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] GameSettings _settings;

        private Controllers _controllers;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _controllers = new Controllers(_settings);
        }

        private void Update()
        {
            for (var i = 0; i < _controllers.Length; i++)
                _controllers[i].Execute();
        }

        #endregion

    }
}
