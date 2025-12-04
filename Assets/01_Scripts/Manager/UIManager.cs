using UnityEngine;
using UnityEngine.SceneManagement;

namespace _01_Scripts.Manager
{
    public class UIManager : MonoBehaviour
    {
        public void StartButton()
        {
            SceneManager.LoadScene("Loading");
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}