using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] Button _buttonStartGame;


        private void Start()
        {
            _buttonStartGame.onClick.AddListener(StartGame);
        }


        void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        void Quit()
        {
            Application.Quit();
        }


        private void OnDestroy()
        {
            _buttonStartGame.onClick.RemoveListener(StartGame);
        }
    }
}