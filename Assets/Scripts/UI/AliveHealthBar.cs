using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AliveHealthBar : MonoBehaviour
    {
        private Slider _slider;
        [SerializeField] private HealthSystem healthSystem;
        
        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            _slider.value = healthSystem.Health;
            _slider.maxValue = healthSystem.MaxHealth;
        }

        private void Update()
        {
            _slider.value = healthSystem.Health;
            _slider.maxValue = healthSystem.MaxHealth;
        }
    }
}