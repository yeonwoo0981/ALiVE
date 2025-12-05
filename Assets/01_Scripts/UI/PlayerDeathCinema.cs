using System;
using _01_Scripts.System;
using UnityEngine;
using UnityEngine.UI;

namespace _01_Scripts.UI
{
    public class PlayerDeathCinema : MonoBehaviour
    {
        private HealthSystem _healthSystem;
        [SerializeField] DeathCinema deathCinemaImage;
        
        private void Awake()
        {
            _healthSystem = GetComponent<HealthSystem>();
            deathCinemaImage.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _healthSystem.OnDead += DeathCinema;
        }

        private void DeathCinema()
        {
            deathCinemaImage.gameObject.SetActive(true);
        }
        
        private void OnDisable()
        {
            _healthSystem.OnDead += DeathCinema;
        }
    }
}