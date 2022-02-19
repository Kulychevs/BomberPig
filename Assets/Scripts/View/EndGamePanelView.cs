using UnityEngine;
using UnityEngine.UI;


namespace BomberPig
{
    public sealed class EndGamePanelView : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;

        public Button GetRestartButton => _restartButton;
    }
}
