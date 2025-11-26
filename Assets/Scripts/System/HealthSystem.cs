using UnityEngine;

namespace System
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
            OnDamage?.Invoke();
            if (Health <= 0)
            {
                OnDead?.Invoke();
            }
        }
        
        public void Heal(float amount)
        {
            Health += amount;
            OnHeal?.Invoke();
            ;
        }
    }
}