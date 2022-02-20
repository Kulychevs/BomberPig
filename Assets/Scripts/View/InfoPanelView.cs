using UnityEngine;
using UnityEngine.UI;


namespace BomberPig
{
    public sealed class InfoPanelView : MonoBehaviour
    {
        [SerializeField] private Image _bombImage;
        [SerializeField] private TMPro.TMP_Text _scoreText;

        public void SetFillAmount(float fillAmount)
        {
            _bombImage.fillAmount = fillAmount;
        }

        public void SetScoreText(int score)
        {
            _scoreText.text = $"Score: {score}";
        }
    }
}
