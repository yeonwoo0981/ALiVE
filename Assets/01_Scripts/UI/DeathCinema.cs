using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _01_Scripts.UI
{
    public class DeathCinema : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI aliveTimeText;
        private Coroutine _running;
        
        public void Show(int min, int sec)
        {
            aliveTimeText.text = $"생존 시간 - {min:D2}:{sec:D2}";
            gameObject.SetActive(true);

            if (_running != null) StopCoroutine(_running);
            _running = StartCoroutine(RestartCoroutine());
        }

        private IEnumerator RestartCoroutine()
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Loading");
        }
    }
}