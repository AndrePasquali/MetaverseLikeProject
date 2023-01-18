using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Genies.Menu
{
    public class MenuBack : MonoBehaviour
    {
        public Button Button => _button ?? (_button = GetComponent<Button>());
        private Button _button;

        private void Start() => Button.onClick.AddListener(BackToTheMainScene);

        private void BackToTheMainScene() => SceneManager.LoadScene(0);
    }
}
