using Genies.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Genies.Menu
{
    public class MenuPlay: MonoBehaviour
    {
        public Button M_Button => m_button ?? (m_button = GetComponent<Button>());
        private Button m_button;
        [SerializeField] private UIFadeOutAnimation _fadeOut;

        private void Start() => M_Button.onClick.AddListener(PlayEffect);

        private void PlayEffect() => _fadeOut.StartAnimation();
        
        public void LoadPlayScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}