using _01_Scripts.System;
using TMPro;
using UnityEngine;

namespace _01_Scripts.UI
{
    public class AliveTimeText : MonoBehaviour
    {
        [SerializeField] private HealthSystem healthSystem;
        [SerializeField] private DeathCinema deathCinema;
        private TextMeshProUGUI _text;
        public float CurrentSec { get; private set; } = 0;
        public int CurrentMin { get; private set; } = 0;
        
        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            healthSystem.OnDead += SetAliveUI;
            // 게임오버 이벤트 구독
        }

        private void Update()
        {
            CurrentSec += Time.deltaTime;
            if (CurrentSec >= 60)
            {
                CurrentMin++;
                CurrentSec = 0;
            }
            
            _text.text = $"ALiVE TIME - {CurrentMin:D2}:{(int)CurrentSec:D2}";
        }

        private void SetAliveUI()
        {
            int secInt = (int)CurrentSec;
            if (deathCinema != null)
                deathCinema.Show(CurrentMin, secInt);
            // 여따가 게임 오버 됐을 때 UI에 생존시간 넘기기
        }
        
        private void OnDisable()
        {
            healthSystem.OnDead -= SetAliveUI;
            // 게임오버 이벤트 해제
        }
    }
}
