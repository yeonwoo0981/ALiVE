using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        public void StartButton()
        {
            SceneManager.LoadScene("Game");
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}