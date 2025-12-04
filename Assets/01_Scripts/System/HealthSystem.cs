using System;
using UnityEngine;

namespace _01_Scripts.System
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private float health;
        [field:SerializeField] public float MaxHealth { get; private set; }

        public float Health
        {
            get => health;
            set => health = Mathf.Clamp(value, 0, MaxHealth);
        }
        
        public Action OnDamage;
        public Action OnHeal;
        public Action OnDead;

        private void Start()
        {
            Health = MaxHealth;
        }

        public void Damage(float damage)
        {
            Health -= damage;
            Debug.Log($"{damage} 만큼의 피해를 입음");
            Debug.Log($"현재 체력: {Health}");
            OnDamage?.Invoke();
            if (Health <= 0)
            {
                Debug.Log("사망");
                OnDead?.Invoke();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
                Damage(5);
            if (Input.GetKeyDown(KeyCode.H))
                Heal(5);
        }

        public void Heal(float amount)
        {
            Health += amount;
            Debug.Log($"{amount}만큼 체력 회복");
            Debug.Log($"현재 체력: {Health}");
            OnHeal?.Invoke();
        }
    }
}